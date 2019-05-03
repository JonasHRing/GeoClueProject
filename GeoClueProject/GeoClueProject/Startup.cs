using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoClueProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Session;

namespace GeoClueProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Read the connection string (from appsettings.json during dev)
            var connString = configuration.GetConnectionString("DefaultConnection");

            services.AddHttpContextAccessor();
            services.AddDbContext<MyIdentityContext>(o => o.UseSqlServer(connString));
            services.AddIdentity<MyIdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<MyIdentityContext>()
            .AddDefaultTokenProviders();

            // This is only needed if your login path should be anything else than "/Account/Login" 
            services.ConfigureApplicationCookie(o => o.LoginPath = "/LogIn");

            services.AddTransient<AccountService>();
            services.AddSingleton<HomeService>();
            services.AddSingleton<ApiService>();
            

            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            
        }
    }
}
