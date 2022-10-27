using AutoMapper;
using Dot.Net.PoseidonApi.Controllers.Domain;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;

namespace Dot.Net.PoseidonApi.Controllers
{
    [Route("[controller]")]
    public class RatingController : EntityController<Rating, RatingDTO>
    {
        public RatingController(EntityRepository<Rating> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}