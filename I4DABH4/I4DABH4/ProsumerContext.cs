using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace I4DABH4.Models
{
    public partial class ProsumerContext : DbContext
    {
        public virtual DbSet<Prosumer> Prosumers { get; set; }
        public virtual DbSet<GridSettings> GridSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=10.29.0.29;Initial Catalog=F18I4DABH4Gr8;Integrated Security=False;User ID=F18I4DABH4Gr8;Password=F18I4DABH4Gr8;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prosumer>(entity => { entity.HasKey(d => d.ProsumerId);});
        }
    }
}
