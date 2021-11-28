using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SportsTeamManager.Repositories;
using SportsTeamManager.Repositories.Interfaces;
using SportsTeamManager.Services;
using SportsTeamManager.Services.Interfaces;

namespace SportsTeamManager
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SportsTeamManager", Version = "v1" });
            });

            services.AddSingleton<IInMemoryContext, InMemoryContext>();

            services.AddSingleton<IGameRepository, GameRepository>();
            services.AddSingleton<IPlayerRepository, PlayerRepository>();
            services.AddSingleton<ITeamRepository, TeamRepository>();

            services.AddSingleton<ITeamManagerService, TeamManagerService>();
            services.AddSingleton<IRequestValidator, RequestValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportsTeamManager v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
