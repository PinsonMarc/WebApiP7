using AutoMapper;
using Dot.Net.PoseidonApi.Controllers.Domain;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;

namespace Dot.Net.PoseidonApi.Controllers
{
    public class RatingController : EntityController<Rating, RatingDTO>
    {
        public RatingController(IEntityRepository<Rating> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}