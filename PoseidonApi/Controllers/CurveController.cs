using AutoMapper;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;

namespace Dot.Net.PoseidonApi.Controllers
{
    public class CurveController : EntityController<CurvePoint, CurvePointDTO>
    {
        public CurveController(IEntityRepository<CurvePoint> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}