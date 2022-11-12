using Microsoft.AspNetCore.Identity;

namespace PoseidonApi.Entities
{
    public class ApiUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}