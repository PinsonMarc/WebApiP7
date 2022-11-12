using Microsoft.AspNetCore.Identity;

namespace Dot.Net.PoseidonApi.Entities
{
    public class ApiUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}