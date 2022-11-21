using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PoseidonApi.Model;
using System.Net.Http;
using System.Text;
using TheCarHub.Models;

namespace PoseidonApi.Tests
{
    internal static class TestHelper
    {
        public static ApplicationDbContext CreateInMemoryDb()
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDbForTesting")
                .Options;
            return new ApplicationDbContext(options);
        }

        public static IMapper GetMapper()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }

        public static StringContent CreateStringContent(object content)
        {

            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
