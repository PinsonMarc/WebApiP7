using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PoseidonApi.Entities;
using PoseidonApi.Model;
using PoseidonApi.Model.Identity;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PoseidonApi.Tests.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(ApplicationDbContext));
                        services.AddDbContext<ApplicationDbContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsAdminAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        //protected async Task<string> CreatePostAsync(CreatePostRequest request)
        //{
        //    var response = await TestClient.PostAsJsonAsync(ApiRoutes.Posts.Create, request);
        //    return await response.Content.ReadAsAsync<PostResponse>();
        //}

        private async Task<string> GetJwtAsync()
        {
            var response = await TestClient.PostAsJsonAsync("/login", new UserDTO
            {
                UserName = "Administrator",
                Password = "pass@word1"
            });

            var registrationResponse = await response.Content.ReadFromJsonAsync<TokenRequest>();
            return registrationResponse.Token;
        }
    }
}