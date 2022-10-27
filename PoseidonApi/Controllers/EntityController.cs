using AutoMapper;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;

namespace Dot.Net.PoseidonApi.Controllers
{
    //[Route("[controller]")]
    public abstract class EntityController<Entity, DTO> : ControllerBase 
        where Entity : APIEntity 
        where DTO : APIEntityDTO
    {
        protected readonly EntityRepository<Entity> _repo;
        protected readonly IMapper _mapper;

        public EntityController(EntityRepository<Entity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // TODO: Inject Curve Point service

        [HttpGet("[controller]/list")]
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


        [HttpGet("[controller]/add")]
        public async Task<IActionResult> Add([FromBody] DTO dto)
        {
            if (ModelState.IsValid)
            {
                Entity entity = _mapper.Map<DTO, Entity>(dto);

                await _repo.AddAsync(entity);
                return Redirect("[controller]/list");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("[controller]/update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTO dto)
        {
            Entity entity = await _repo.GetByIdAsync(id);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                entity = _mapper.Map<DTO, Entity>(dto);
                entity.Id = id;
                await _repo.UpdateAsync(entity);
                return Redirect("[controller]/list");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("[controller]")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Entity entity = await _repo.GetByIdAsync(id);
                if (entity == null) return NotFound();

                await _repo.DeleteAsync(entity);

                return Redirect("[controller]/list");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}