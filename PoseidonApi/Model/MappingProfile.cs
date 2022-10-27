﻿using AutoMapper;
using Dot.Net.PoseidonApi.Controllers;
using Dot.Net.PoseidonApi.Controllers.Domain;
using Dot.Net.PoseidonApi.Entities;

namespace TheCarHub.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BidList, BidListDTO>().ReverseMap();
            CreateMap<CurvePoint, CurvePointDTO>().ReverseMap();
            CreateMap<Rating, RatingDTO >().ReverseMap();
            CreateMap<Rule, RuleDTO>().ReverseMap();
            CreateMap<Trade, TradeDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}