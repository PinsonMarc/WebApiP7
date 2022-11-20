using PoseidonApi.Entities;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonApi.Tests.IntegrationTests
{
    public class RoutingTestAsync : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            // Arrange
            await AuthenticateAsAdminAsync();

            // Act
            var response = await TestClient.GetAsync("/BidList");
            var responseContent = await response.Content.ReadFromJsonAsync<IEnumerable<BidList>>();
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Empty(responseContent);
        }
        //var response = await TestClient.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", createdPost.Id.ToString()));

    }
}