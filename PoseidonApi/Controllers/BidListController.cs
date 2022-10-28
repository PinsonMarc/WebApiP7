using AutoMapper;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Mvc;
using PoseidonApi.Repositories;

namespace Dot.Net.PoseidonApi.Controllers
{
    public class BidListController : EntityController<BidList, BidListDTO>
    {
        public BidListController(EntityRepository<BidList> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}