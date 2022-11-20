using Moq;
using PoseidonApi.Entities;
using PoseidonApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonApi.Tests.IntegrationTests
{
    public class ControllerTests
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfBrainstormSessions()
        {
            //// Arrange
            //var mockRepo = new Mock<EntityRepository<BidList>>();
            //mockRepo.Setup(repo => repo.ListAsync())
            //    .ReturnsAsync(GetTestSessions());
            //var controller = new HomeController(mockRepo.Object);

            //// Act
            //var result = await controller.Index();

            //// Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
            //    viewResult.ViewData.Model);
            //Assert.Equal(2, model.Count());
        }
    }
}
