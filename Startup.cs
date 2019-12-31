using CursoASPNetCoreBaltaIO.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProductCatalog.Data;

namespace ProductCatalog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddResponseCompression(cfg => cfg.EnableForHttps = true);

            services.AddScoped<StoreDataContext>();
            services.AddTransient<ProductRepository>();
            services.AddTransient<CategoryRepository>();

            services.AddSwaggerGen(cfg => 
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo() { Title = "Bruno Store", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(cfg =>
            {
                cfg.SwaggerEndpoint("v1/swagger.json", "Bruno Store - V1");
            });

            app.UseRouting();

            app.UseEndpoints(cfg => 
            {
                cfg.MapControllers();
            });

            app.UseResponseCompression();
        }
    }
}
