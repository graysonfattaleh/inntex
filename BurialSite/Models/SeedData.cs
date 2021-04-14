using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BurialSite.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BurialSite.Models
{
    /// <summary>
    /// Soe seed data for if the DB is not populated.
    /// </summary>
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

            if (!context.BurialLocations.Any())
            {
                context.AddRange(
                   
                    new BurialLocation
                    {
                        BurialLocationId = 1,
                        Dig_Site_Name = "Gamous",
                        N_S_Grid_Site_Lower = 33,
                        E_W_Grid_Site_Lower = 4,
                        E_W_Grid_Site_Upper = 43,
                        N_S_Grid_Site_Upper = 11,
                        
                    }

                    
                  );
                
                    
            }
            context.SaveChanges();

        }
    }

}