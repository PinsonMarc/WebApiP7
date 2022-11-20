using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PoseidonApi.Entities
{
    //Mostly use for easy constraint
    public class APIEntityDTO
    {

        [BindNever]
        [Ignore]
        public int? Id { get; set; }
    }
}