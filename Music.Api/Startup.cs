using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Music.Api.Configurations;
using Music.Api.Extensions;
using Music.Core;
using Music.Core.Services;
using Music.Data;
using Music.Services;

namespace Music.Api
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
            var apiConfiguration = getApiConfiguration(services);
            services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc(apiConfiguration.Version, (OpenApiInfo)apiConfiguration);
                })
                .ConfigureSwaggerGen(options =>
                {
                    options.CustomSchemaIds(x => x.FullName);
                    var basePath = Directory.GetCurrentDirectory();
                    var xmlFileName = typeof(Startup).Namespace;
                    var xmlPath = Path.Combine(basePath, $"{xmlFileName}.xml");
                    options.IncludeXmlComments(xmlPath);
                }); 

            var connectionString = Configuration.GetConnectionString("Default");
            services               
                .AddDbContext<MusicDbContext>(options => 
                    options.UseSqlServer(
                        connectionString,
                        builder => builder.MigrationsAssembly("Music.Data"))
                )
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddTransient<ISongService, SongService>()  
                .AddTransient<IArtistService, ArtistService>()                
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<ApiConfiguration> apiOption)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            var apiConfiguration = apiOption.Value;
            app.UseSwagger(); 
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", apiConfiguration.Name);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private ApiConfiguration getApiConfiguration(IServiceCollection services)
        {
            return services
                .AddCustomOptions(Configuration)
                .GetRequiredService<IOptions<ApiConfiguration>>()
                .Value;
        }
    }
}
