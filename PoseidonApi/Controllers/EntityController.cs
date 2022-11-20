using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoseidonApi.Entities;
using PoseidonApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoseidonApi.Controllers
{
    [Authorize]
    public abstract class EntityController<Entity, DTO> : ControllerBase
        where Entity : APIEntity
        where DTO : APIEntityDTO
    {
        protected IEntityRepository<Entity> _repo;
        protected IMapper _mapper;
        protected ILogger<EntityController<Entity, DTO>> _logger;

        public EntityController(IEntityRepository<Entity> repo, IMapper mapper, ILogger<EntityController<Entity, DTO>> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("[controller]/list")]
        [HttpGet("[controller]")]
        public async Task<ActionResult<IEnumerable<DTO>>> ListAsync()
        {
            try
            {
                var res = await _repo.FindAllAsync();

                DTO[] list = _mapper.Map<Entity[], DTO[]>(res);
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(ListAsync)}");
                return StatusCode(500, ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("[controller]/add")]
        public async Task<IActionResult> AddAsync([FromBody] DTO dto)
        {
            dto.Id = null;
            if (ModelState.IsValid)
            {
                Entity entity = _mapper.Map<DTO, Entity>(dto);

                await _repo.AddAsync(entity);
                return RedirectToAction("list");
            }
            else
            {
                _logger.LogWarning(ModelState.ToString());
                return BadRequest(ModelState);
            }
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("[controller]/update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            Entity entity = await _repo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            DTO dto = _mapper.Map<Entity, DTO>(entity);

            return Ok(dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("[controller]/update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DTO dto)
        {
            Entity entity = await _repo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                dto.Id = id;
                _mapper.Map<DTO, Entity>(dto, entity);
                await _repo.UpdateAsync(entity);
                return RedirectToAction("list");
            }
            else
            {
                _logger.LogWarning(ModelState.ToString());
                return BadRequest(ModelState);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("[controller]/delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                Entity entity = await _repo.GetByIdAsync(id);
                if (entity == null) return NotFound();

                await _repo.DeleteAsync(entity);

                return RedirectToAction("list");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteAsync)}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}