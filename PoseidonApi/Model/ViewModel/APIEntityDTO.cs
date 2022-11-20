using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PoseidonApi.Entities
{
    public class APIEntityDTO
    {

        [BindNever]
        [Ignore]
        public int? Id { get; set; }
    }
}