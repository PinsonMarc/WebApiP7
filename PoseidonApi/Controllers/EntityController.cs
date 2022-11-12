using AutoMapper;
using PoseidonApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoseidonApi.Controllers
{
    public abstract class EntityController<Entity, DTO> : ControllerBase
        where Entity : APIEntity
        where DTO : APIEntityDTO
    {
        protected readonly IEntityRepository<Entity> _repo;
        protected readonly IMapper _mapper;

        public EntityController(IEntityRepository<Entity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // TODO: Inject Curve Point service

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("[controller]/list")]
        [HttpGet("[controller]")]
        public async Task<ActionResult<IEnumerable<DTO>>> List()
        {
            try
            {
                var res = await _repo.FindAllAsync();

                DTO[] list = _mapper.Map<Entity[], DTO[]>(res);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("[controller]/add")]
        public async Task<IActionResult> Add([FromBody] DTO dto)
        {
            if (ModelState.IsValid)
            {
                Entity entity = _mapper.Map<DTO, Entity>(dto);

                await _repo.AddAsync(entity);
                return RedirectToAction("list");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("[controller]/update/{id}")]
        public async Task<IActionResult> Update(int id)
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
        public async Task<IActionResult> Update(int id, [FromBody] DTO dto)
        {
            Entity entity = await _repo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                entity = _mapper.Map<DTO, Entity>(dto);
                entity.Id = id;
                await _repo.UpdateAsync(entity);
                return RedirectToAction("list");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("[controller]/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
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
                return StatusCode(500, ex.Message);
            }
        }
    }
}