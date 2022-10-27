using AutoMapper;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;

namespace Dot.Net.PoseidonApi.Controllers
{
    [Route("[controller]")]
    public class RuleController : EntityController<Rule, RuleDTO>
    {
        public RuleController(EntityRepository<Rule> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}