using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PoseidonApi.Controllers;
using PoseidonApi.Entities;
using PoseidonApi.Model;
using PoseidonApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TheCarHub.Models;
using Xunit;

namespace PoseidonApi.Tests.IntegrationTests
{
    public class BidListControllerTest
    {
        private BidListController _controller;
        private ApplicationDbContext _context;

        private BidListDTO _dto = new BidListDTO
        {
            Account = "Account",
            Type = "Type"
        };

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
        public async Task Add_CheckDbChange()
        {
            // Act
            var result = await _controller.AddAsync(_dto);
            var dbResult = _context.BidLists.Where(x => x.Account == _dto.Account && x.Type == _dto.Type);

            // Assert
            Assert.Single(dbResult);
        }

        [Fact]
        public async Task Add_IdNotInclueded()
        {
            _dto.Id = 999999;
            // Act
            await _controller.AddAsync(_dto);
            var result = _context.BidLists.Where(x => x.Id == 999999);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task Add_BadRequest()
        {
            var dto = new BidListDTO();
            // Act
            var result = await _controller.AddAsync(dto);
            var dbResult = _context.BidLists.ToList();

            // Assert
            Assert.Empty(dbResult);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_CheckDbChange()
        {
            // Act
            await _controller.AddAsync(_dto);
            await _controller.DeleteAsync(1);
            var dbResult = _context.BidLists.Where(x => x.Account == _dto.Account && x.Type == _dto.Type);
            // Assert
            Assert.Empty(dbResult);
        }


        [Fact]
        public async Task Delete_NotFound()
        {
            // Act
            var result = await _controller.DeleteAsync(1000);
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Update_CheckDbChange()
        {
            // Act
            await _controller.AddAsync(_dto);
            _dto.Commentary = "Comment";
            _dto.Type = "Type2";
            var result = await _controller.UpdateAsync(1, _dto);
            var dbResult = _context.BidLists.Where(
                x => x.Account == _dto.Account 
                && x.Type == _dto.Type 
                && x.Commentary == "Comment"
            );

            // Assert
            Assert.Single(dbResult);
        }

        [Fact]
        public async Task Update_CannotChangeId()
        {
            // Act
            await _controller.AddAsync(_dto);
            _dto.Type = "Type2";
            _dto.Id = 5;
            var result = await _controller.UpdateAsync(1, _dto);
            var dbResult = _context.BidLists.Where(x => x.Id == 5);

            // Assert
            Assert.Empty(dbResult);
        }
    }
}
