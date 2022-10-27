using AutoMapper;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;

namespace Dot.Net.PoseidonApi.Controllers
{
    [Route("[controller]")]
    public class TradeController : EntityController<Trade, TradeDTO>
    {
        public TradeController(EntityRepository<Trade> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}