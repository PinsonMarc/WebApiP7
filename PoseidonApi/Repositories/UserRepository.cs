using Dot.Net.PoseidonApi.Data;
using Dot.Net.PoseidonApi.Domain;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Dot.Net.PoseidonApi.Repositories
{
    public class UserRepository
    {
        public ApplicationDbContext _context { get; }

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

        public void Add(User user)
        {
        }

        public User FindById(int id)
        {
            return null;
        }
    }
}