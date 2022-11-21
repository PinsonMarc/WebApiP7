using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PoseidonApi.Entities;
using PoseidonApi.Model;
using PoseidonApi.Model.Identity;
using System.Linq;
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
            //This create a mirror application, at the exception of using in memory db
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                        services.Remove(descriptor);
                        services.AddDbContext<ApplicationDbContext>(options => { options.UseInMemoryDatabase("TestDb"); });
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        //Add admin authentication directly to TestClient Headers
        protected async Task AuthenticateAsAdminAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        //Allow easy authentication for testing
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