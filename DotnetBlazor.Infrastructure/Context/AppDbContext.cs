using Microsoft.EntityFrameworkCore;
using DotnetBlazor.Domain.Entities;

namespace DotnetBlazor.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Balance> Balances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camera>()
                .HasMany(b => b.Balances)
                .WithMany(c => c.Cameras)
                .UsingEntity(j => j.ToTable("CameraBalances"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
