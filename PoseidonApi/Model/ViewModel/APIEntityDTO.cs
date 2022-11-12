using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PoseidonApi.Entities
{
    public class APIEntityDTO
    {

        [BindNever]
        public int Id { get; set; }
    }
}