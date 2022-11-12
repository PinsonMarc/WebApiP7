using Microsoft.AspNetCore.Identity;
using System;

namespace Dot.Net.PoseidonApi.Entities
{
    public class ApiUser : IdentityUser
    {
        public string Fullname { get; set; }
    }
}