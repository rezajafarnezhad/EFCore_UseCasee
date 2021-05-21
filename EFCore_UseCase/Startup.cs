using EFCore.Application;
using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.Infra.EFCore;
using EFCore.Infra.EFCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_UseCase
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
            services.AddRazorPages();

            services.AddTransient<IProductRepo, ProductRepo>();
            services.AddTransient<IProductApplication, ProductApplication>();

            services.AddTransient<IProductCategoryRepo, ProductCategoryRepo>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

            var Connection = Configuration.GetConnectionString("EF_useCaseConnection");
            services.AddDbContext<EFContext>(c => c.UseSqlServer(Connection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
