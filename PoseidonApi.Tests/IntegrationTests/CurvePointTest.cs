using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PoseidonApi.Controllers;
using PoseidonApi.Entities;
using PoseidonApi.Model;
using PoseidonApi.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonApi.Tests.IntegrationTests
{
    public class CurvePointTest
    {
        private CurveController _controller;
        private ApplicationDbContext _context;

        private CurvePointDTO _dto = new CurvePointDTO();

        public CurvePointTest()
        {
            // Arrange
            _context = TestHelper.CreateInMemoryDb();

            var repo = new EntityRepository<CurvePoint>(_context);
            var logger = Mock.Of<ILogger<CurveController>>();
            var mapper = TestHelper.GetMapper();

            _controller = new CurveController(repo, mapper, logger);
        }

        [Fact]
        public async Task Add_CheckDbChange()
        {
            _dto.CurveId = 1;
            // Act
            var result = await _controller.AddAsync(_dto);
            var dbResult = _context.CurvePoints.Where(x => _dto.CurveId == x.CurveId);

            // Assert
            Assert.Single(dbResult);
        }

        [Fact]
        public async Task Add_IdNotInclueded()
        {
            _dto.CurveId = 1;
            _dto.Id = 999999;
            // Act
            await _controller.AddAsync(_dto);

            // Assert
            Assert.DoesNotContain<CurvePoint>(_context.CurvePoints, x => x.Id == 999999);
        }

        [Fact]
        public async Task Delete_CheckDbChange()
        {
            // Act
            _dto.CurveId = 4;
            await _controller.AddAsync(_dto);
            await _controller.DeleteAsync(_context.CurvePoints.ToList().Count);
            // Assert
            Assert.DoesNotContain<CurvePoint>(_context.CurvePoints, x => x.CurveId == _dto.CurveId);
        }


        [Fact]
        public async Task Delete_NotFound()
        {
            // Act
            var result = await _controller.DeleteAsync(5555);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Update_CheckDbChange()
        {
            _dto.CurveId = 1;
            var now = DateTime.Now;
            // Act
            await _controller.AddAsync(_dto);
            _dto.CreationDate = now;
            _dto.CurveId = 10;
            var result = await _controller.UpdateAsync(_context.CurvePoints.ToList().Count, _dto);
            // Assert
            Assert.Contains<CurvePoint>(_context.CurvePoints,
                x => x.CreationDate == now
                && x.CurveId == _dto.CurveId);
        }

        [Fact]
        public async Task Update_CannotChangeId()
        {
            _dto.CurveId = 5;
            // Act
            await _controller.AddAsync(_dto);
            _dto.Id = 8888;
            var result = await _controller.UpdateAsync(_context.CurvePoints.ToList().Count, _dto);
            // Assert
            Assert.DoesNotContain<CurvePoint>(_context.CurvePoints, x => x.Id == 8888);
        }

        [Fact]
        public async Task Update_NotFound()
        {
            // Act
            var result = await _controller.UpdateAsync(7777);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
