using System;
using BurialSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurialSite.Models
{
    /// <summary>
    /// Our inherited identity context with the classes we overload it with.
    /// Built in to aspnet core.
    /// </summary>
    public class ArcDBContext : IdentityDbContext<ResearchUser,Role,int>
    {
        public ArcDBContext(DbContextOptions<ArcDBContext> options) : base(options)
        {



        }

        public DbSet<TestEnt> Tests { get; set; }
        public DbSet<Burial> Burials { get; set; }
        public DbSet<BurialLocation> BurialLocations { get; set; }
        public DbSet<FileUrl> FileUrls { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<OneToOneField> OneToOneFields { get; set; }
        public DbSet<OneToOneValue> OneToOneValues { get; set; }
      


    }
}
