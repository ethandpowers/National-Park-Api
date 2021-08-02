using Microsoft.EntityFrameworkCore;
using NationalParkApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkApi.Data
{
    public class NpContext:DbContext
    {
        public NpContext(DbContextOptions<NpContext> options):base(options)
        {
        }

        public DbSet<Park> Parks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<CommonName> CommonNames { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
