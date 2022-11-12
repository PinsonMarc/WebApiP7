using AutoMapper;
using PoseidonApi.Controllers;
using PoseidonApi.Controllers.Domain;
using PoseidonApi.Entities;

namespace TheCarHub.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BidList, BidListDTO>().ReverseMap();
            CreateMap<CurvePoint, CurvePointDTO>().ReverseMap();
            CreateMap<Rating, RatingDTO>().ReverseMap();
            CreateMap<Rule, RuleDTO>().ReverseMap();
            CreateMap<Trade, TradeDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
