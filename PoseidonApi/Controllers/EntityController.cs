using AutoMapper;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public ActionResult<IEnumerable<DTO>> List()
        {
            throw new NotImplementedException();
        }


        [HttpGet("[controller]/add")]
        public IActionResult Add([FromBody] DTO dto)
        {
            return Ok("curvePoint/add");
        }

        [HttpPost("[controller]/update/{id}")]
        public IActionResult Update(int id, [FromBody] DTO dto)
        {
            // TODO: check required fields, if valid call service to update Curve and return Curve list
            return Redirect("[controller]/list");
        }

        [HttpDelete("[controller]")]
        public IActionResult Delete(int id)
        {
            // TODO: Find Curve by Id and delete the Curve, return to Curve list

            return Redirect("[controller]/list");
        }
    }
}