using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Moq;
using PoseidonApi.Entities;
using PoseidonApi.Model;
using PoseidonApi.Repositories;
using System;
using System.Collections.Generic;
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
    }
}
