using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurialSite.Models;
using BurialSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static BurialSite.Services.S3Service;
using Microsoft.AspNetCore.Identity;

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
            //ahahhhdhdfhdhdh
            services.AddDbContext<ArcDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DBConnector")));
            // what even photo service
            services.AddSingleton<IS3Service, S3Service>();
            services.AddAWSService<IAmazonS3>();

            // add identity service
            services.AddIdentity<ResearchUser, Role>(options =>
             {
                 options.User.RequireUniqueEmail = true;
                 options.SignIn.RequireConfirmedAccount = true;
             }
            )
                .AddDefaultUI()
                .AddEntityFrameworkStores<ArcDBContext>()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("researcherpolicy",
                        builder => builder.RequireRole("SuperAdmin", "Researcher"));
                    options.AddPolicy("superadminpolicy",
                        builder => builder.RequireRole("SuperAdmin"));
                }
                );
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

            app.UseAuthentication();
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

                // navigation 
                endpoints.MapControllerRoute("Research",
                   "/Research/Admin",
                   new { Controller = "Research", Action = "MangeUsers" }

                    );

                endpoints.MapControllerRoute("ResearchSite",
                   "/Research/AddSite",
                   new { Controller = "Research", Action = "AddSite" }

                    );

                endpoints.MapControllerRoute("ResearchPhoto",
                  "/Research/UploadPhotos",
                  new { Controller = "Research", Action = "UploadPhotos" }

                   );
                // Research CRUD

                endpoints.MapControllerRoute("AddBurial",
                    "/Research/AddBurial",
                    new { Controller = "Research", Action = "CreateBurial" }
                    );
                endpoints.MapControllerRoute("DeleteBurial",
                  "/Research/DeleteBurial",
                  new { Controller = "Research", Action = "DeleteSiteBurial" }
                  );

                endpoints.MapControllerRoute("BurialDetails",
               "/Research/BurialDetails",
               new { Controller = "Research", Action = "BurialDetails" }
               );
                // for like buria details redirection?
                endpoints.MapControllerRoute("BurialDetailsGet",
              "/Research/BurialDetails/{BurialId:int}",
              new { Controller = "Research", Action = "BurialDetails" }
              );

                // Role management actions
                endpoints.MapControllerRoute(
                    name: "role",
                    pattern: "{controller=Role}/{action=Index}");
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
