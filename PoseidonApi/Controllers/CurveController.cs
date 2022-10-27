using AutoMapper;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;

namespace Dot.Net.PoseidonApi.Controllers
{
    [Route("[controller]")]
    public class CurveController : EntityController<CurvePoint, CurvePointDTO>
    {
        public CurveController(EntityRepository<CurvePoint> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}