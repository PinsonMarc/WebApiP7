using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PoseidonApi.Entities;
using PoseidonApi.Middleware;
using PoseidonApi.Model;
using PoseidonApi.Repositories;
using PoseidonApi.Services;

namespace PoseidonApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //DB
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            //Authentication
            services.AddIdentity<ApiUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllers();

            //Repos
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddScoped<IAuthManager, AuthManager>();

            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);

            services.ConfigureFluentValidation();

            services.ConfigureAutoMapper();

            services.ConfigureSwaggerDoc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
                context.Database.EnsureCreated();

            app.UseSwagger();
            app.UseSwaggerUI();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<LoggingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
