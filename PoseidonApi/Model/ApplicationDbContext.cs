using Dot.Net.PoseidonApi.Controllers;
using Dot.Net.PoseidonApi.Controllers.Domain;
using Dot.Net.PoseidonApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoseidonApi.Model.Identity;

namespace PoseidonApi.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<Rule> RuleNames { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<CurvePoint> CurvePoints { get; set; }
        public DbSet<BidList> BidLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole{
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole{
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
    }
}