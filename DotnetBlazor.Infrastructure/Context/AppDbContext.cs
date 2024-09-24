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
            base.OnModelCreating(modelBuilder);

            // Configurando relacionamento Many-to-Many entre Balance e Camera
            modelBuilder.Entity<Balance>()
                .HasMany(b => b.Cameras)
                .WithMany(c => c.Balances)
                .UsingEntity<Dictionary<string, object>>(
                    "BalanceCamera",
                    j => j.HasOne<Camera>().WithMany().HasForeignKey("CameraId"),
                    j => j.HasOne<Balance>().WithMany().HasForeignKey("BalanceId")
                );
        }
    }
}
