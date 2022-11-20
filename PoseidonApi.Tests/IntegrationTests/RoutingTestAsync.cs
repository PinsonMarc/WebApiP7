using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using PoseidonApi;
using Xunit;
using PoseidonApi.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using PoseidonApi.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PoseidonApi.Repositories;
using PoseidonApi.Services;
using PoseidonApi.Middleware;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http.Json;
using PoseidonApi.Model.Identity;
using System.Collections.Generic;
using System.Net;

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