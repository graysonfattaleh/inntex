using System;
using Microsoft.EntityFrameworkCore;

namespace BurialSite.Models
{
    public class ArcDBContext : DbContext
    {
        public ArcDBContext(DbContextOptions<ArcDBContext> options) : base(options)
        {



        }

        public DbSet<TestEnt> Tests { get; set; }

    }
}
