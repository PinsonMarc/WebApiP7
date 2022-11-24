using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PoseidonApi.Controllers;
using PoseidonApi.Entities;
using PoseidonApi.Model;
using PoseidonApi.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonApi.Tests.IntegrationTests
{
    public class BidListControllerTest
    {
        private BidListController _controller;
        private ApplicationDbContext _context;

        private BidListDTO _dto = new BidListDTO();

        public BidListControllerTest()
        {
            // Arrange
            _context = TestHelper.CreateInMemoryDb();

            var repo = new EntityRepository<BidList>(_context);
            var logger = Mock.Of<ILogger<BidListController>>();
            var mapper = TestHelper.GetMapper();

            _controller = new BidListController(repo, mapper, logger);
        }

        [Fact]
        public async Task AddCheckDbChange()
        {
            _dto.Account = "Account1";
            _dto.Type = "Type1";
            // Act
            var result = await _controller.AddAsync(_dto);
            var dbResult = _context.BidLists.Where(x => x.Account == _dto.Account && x.Type == _dto.Type);

            // Assert
            Assert.Single(dbResult);
        }

        [Fact]
        public async Task AddIdNotInclueded()
        {
            _dto.Account = "Account2";
            _dto.Type = "Type2";
            _dto.Id = 999999;
            // Act
            await _controller.AddAsync(_dto);

            // Assert
            Assert.DoesNotContain<BidList>(_context.BidLists, x => x.Id == 999999);
        }

        [Fact]
        public async Task DeleteCheckDbChange()
        {
            // Act
            _dto.Account = "Account3";
            _dto.Type = "Type3";
            await _controller.AddAsync(_dto);
            await _controller.DeleteAsync(_context.BidLists.ToList().Count);
            // Assert
            Assert.DoesNotContain<BidList>(_context.BidLists, x => x.Account == _dto.Account && x.Type == _dto.Type);
        }


        [Fact]
        public async Task DeleteNotFound()
        {
            // Act
            var result = await _controller.DeleteAsync(5555);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateCheckDbChange()
        {
            _dto.Account = "Account3";
            _dto.Type = "Type3";
            // Act
            await _controller.AddAsync(_dto);
            _dto.Commentary = "Comment";
            _dto.Type = "Type4";
            var result = await _controller.UpdateAsync(_context.BidLists.ToList().Count, _dto);
            // Assert
            Assert.Contains<BidList>(_context.BidLists,
                x => x.Account == _dto.Account
                && x.Type == _dto.Type
                && x.Commentary == "Comment");
        }

        [Fact]
        public async Task UpdateCannotChangeId()
        {

            _dto.Account = "Account5";
            _dto.Type = "Type5";
            // Act
            await _controller.AddAsync(_dto);
            _dto.Type = "Type6";
            _dto.Id = 8888;
            var result = await _controller.UpdateAsync(_context.BidLists.ToList().Count, _dto);
            // Assert
            Assert.DoesNotContain<BidList>(_context.BidLists, x => x.Id == 8888);
        }

        [Fact]
        public async Task UpdateNotFound()
        {
            // Act
            var result = await _controller.UpdateAsync(7777);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
