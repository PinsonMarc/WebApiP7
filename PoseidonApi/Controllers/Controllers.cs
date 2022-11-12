using AutoMapper;
using PoseidonApi.Controllers;
using PoseidonApi.Controllers.Domain;
using PoseidonApi.Entities;
using PoseidonApi.Repositories;

namespace PoseidonApi.Controllers
{
    public class BidListController : EntityController<BidList, BidListDTO>
    {
        public BidListController(EntityRepository<BidList> repo, IMapper mapper) : base(repo, mapper) {}
    }

    public class CurveController : EntityController<CurvePoint, CurvePointDTO>
    {
        public CurveController(IEntityRepository<CurvePoint> repo, IMapper mapper) : base(repo, mapper) {}
    }

    public class RatingController : EntityController<Rating, RatingDTO>
    {
        public RatingController(IEntityRepository<Rating> repo, IMapper mapper) : base(repo, mapper) {}
    }

    public class RuleController : EntityController<Rule, RuleDTO>
    {
        public RuleController(IEntityRepository<Rule> repo, IMapper mapper) : base(repo, mapper) {}
    }

    public class TradeController : EntityController<Trade, TradeDTO>
    {
        public TradeController(IEntityRepository<Trade> repo, IMapper mapper) : base(repo, mapper) {}
    }
}
