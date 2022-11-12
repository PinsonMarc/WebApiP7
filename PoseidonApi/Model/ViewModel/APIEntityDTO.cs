using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dot.Net.PoseidonApi.Entities
{
    public class APIEntityDTO
    {

        [BindNever]
        public int Id { get; set; }
    }
}