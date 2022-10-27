using AutoMapper;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;

namespace Dot.Net.PoseidonApi.Controllers
{
    public class RuleController : EntityController<Rule, RuleDTO>
    {
        public RuleController(IEntityRepository<Rule> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}