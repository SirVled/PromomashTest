using Microsoft.EntityFrameworkCore;
using PromomashTest.Domain.Entities;

namespace PromomashTest.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Province> Provinces => Set<Province>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(c => c.Provinces)
                      .WithOne(p => p.Country)
                      .HasForeignKey(p => p.CountryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
}
