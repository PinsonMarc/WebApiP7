using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoseidonApi.Controllers;
using PoseidonApi.Controllers.Domain;
using PoseidonApi.Entities;

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
            //Add roles
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );

            //Seed administrator
            var apiUser = new ApiUser
            {
                Id = ADMIN_ID,
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR"
            };

            //set user password
            PasswordHasher<ApiUser> ph = new PasswordHasher<ApiUser>();
            //Password is now hear in clear, an option might be to put this in environment var or in a vault
            apiUser.PasswordHash = ph.HashPassword(apiUser, "pass@word1");

            modelBuilder.Entity<ApiUser>().HasData(apiUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}