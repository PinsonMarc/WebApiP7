using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Identity;
using PoseidonApi.Model;
using System.Linq;

namespace Dot.Net.PoseidonApi.Repositories
{
    public class UserRepository
    {
        protected ApplicationDbContext _context { get; }

        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IdentityUser FindByUserName(string userName)
        {
            return _context.Users.Where(user => user.UserName == userName)
                                  .FirstOrDefault();
        }

        public IdentityUser[] FindAll()
        {
            return _context.Users.ToArray();
        }

        public void Add(UserDTO user)
        {
        }

        public UserDTO FindById(int id)
        {
            return null;
        }
    }
}