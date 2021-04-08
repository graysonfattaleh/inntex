using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurialSite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BurialSite
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
            services.AddControllersWithViews();
            //ahahhhdhdfhdhdh
            services.AddDbContext<ArcDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DBConnector")));

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //PUBLIC PORTAL
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("Research",
                   "/Home/Filter",
                   new { Controller = "Home", Action = "FilterResults" }

                    );

                // RESEARCHER AND ADMIN PORTAL
                endpoints.MapControllerRoute("Research",
                   "/Research",
                   new { Controller = "Research", Action = "Index" }

                    );

                endpoints.MapControllerRoute("Research",
                   "/Research/Admin",
                   new { Controller = "Research", Action = "MangeUsers" }

                    );

                endpoints.MapControllerRoute("Research",
                   "/Research/AddSite",
                   new { Controller = "Research", Action = "AddSite" }

                    );
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
