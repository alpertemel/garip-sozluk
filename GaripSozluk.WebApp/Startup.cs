using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Business.Services;
using GaripSozluk.Data;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using GaripSozluk.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GaripSozluk.WebApp
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
            var connectionString = Configuration.GetConnectionString("AppDatabase");
            services.AddDbContext<GaripSozlukDbContext>(options => options.UseSqlServer(connectionString));


            services.AddIdentity<User, Role>()
               .AddRoles<Role>()
               .AddRoleManager<RoleManager<Role>>()
               .AddEntityFrameworkStores<GaripSozlukDbContext>();


            services.AddScoped<IHeaderService, HeaderService>();

            services.AddScoped<ISearchService, SearchService>();

            services.AddScoped<ISearchService, SearchService>();
            
            services.AddScoped<ISearchRepository, SearchRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IHeaderCategoryService, HeaderCategoryService>();

            services.AddScoped<IHeaderCategoryRepository, HeaderCategoryRepository>();

            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<IPostService, PostService>();

            services.AddScoped<IHeaderRepository, HeaderRepository>();

            services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseStatusCodePages();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
