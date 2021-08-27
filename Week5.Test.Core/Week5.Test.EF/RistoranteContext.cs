using Microsoft.EntityFrameworkCore;
using System;
using Week5.Test.Core.Models;
using Week5.Test.EF.Configurations;

namespace Week5.Test.EF
{
    public class RistoranteContext : DbContext
    {
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<User> Users { get; set; }

        public RistoranteContext(DbContextOptions<RistoranteContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Piatto>(new PiattoConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }
    }
}
