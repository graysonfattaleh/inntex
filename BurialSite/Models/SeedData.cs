using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BurialSite.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BurialSite.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            // makes context variable from create scope guy which is also in start up
            ArcDBContext context = application.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<ArcDBContext>();

            // checks to see if any migrations are needed and makes them
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Tests.Any())
            {
                context.AddRange(
                    new TestEnt
                    {
                        test_string = "this"
                    },
                    new TestEnt
                    {
                        test_string = "might"
                    },
                    new TestEnt
                    {
                        test_string ="work"
                    }
                    );
            }
            context.SaveChanges();

        }
    }

}