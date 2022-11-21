using Newtonsoft.Json;
using PoseidonApi.Entities;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PoseidonApi.Tests.IntegrationTests
{
    public class RoutingTest : IntegrationTest
    {
        [Theory]
        [InlineData("/BidList")]
        [InlineData("/Curve")]
        [InlineData("/Rating/list")]
        [InlineData("/Rule/list")]
        [InlineData("/User/list")]
        public async Task Get_WhitoutAuth_ReturnUnauthorize(string url)
        {
            var response = await TestClient.GetAsync(url);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Theory]
        [InlineData("/Rating/add")]
        [InlineData("/Rule/add")]
        [InlineData("/User/register")]
        public async Task Post_WhitoutAuth_ReturnUnauthorize(string url)
        {
            var response = await TestClient.PostAsync(url, new StringContent(""));

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }



        [Theory]
        [InlineData("/Rating/delete/1")]
        public async Task Delete_WhitoutAuth_ReturnUnauthorize(string url)
        {
            var response = await TestClient.DeleteAsync(url);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetSwagger_ReturnSuccess()
        {
            // Act
            var response = await TestClient.GetAsync("/swagger");

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/BidList")]
        [InlineData("/Curve")]
        [InlineData("/Rating/list")]
        [InlineData("/Rule/list")]
        [InlineData("/User/list")]
        public async Task Get_WithAuth_ReturnSuccess(string url)
        {
            await AuthenticateAsAdminAsync();
            var response = await TestClient.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString().Trim());
        }

        [Fact]
        public async Task Register_And_Login_ReturnSuccess()
        {
            UserDTO dto = new UserDTO
            {
                UserName = "integrationTestUser2",
                Password = "Myp@ssword1"
            };
            UserLoginDTO loginDTO = new UserLoginDTO
            {
                UserName = dto.UserName,
                Password = dto.Password
            };

            await AuthenticateAsAdminAsync();

            var response = await TestClient.PostAsync("/User/register", TestHelper.CreateStringContent(dto));
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            response = await TestClient.PostAsync("/login", TestHelper.CreateStringContent(loginDTO));

            response.EnsureSuccessStatusCode();
        }
    }
}