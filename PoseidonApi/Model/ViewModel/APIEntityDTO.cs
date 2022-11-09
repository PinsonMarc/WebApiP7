using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Dot.Net.PoseidonApi.Entities
{
    public class APIEntityDTO
    {

        [BindNever]
        public int Id { get; set; }
    }
}