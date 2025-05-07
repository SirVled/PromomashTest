using Microsoft.EntityFrameworkCore;
using PromomashTest.Domain.Entities;

namespace PromomashTest.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Province> Provinces => Set<Province>();

        public DbSet<User> Users => Set<User>();

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

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();

                entity.HasOne(u => u.Country)
                      .WithMany()
                      .HasForeignKey(u => u.CountryId);

                entity.HasOne(u => u.Province)
                      .WithMany()
                      .HasForeignKey(u => u.ProvinceId);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });
        }
    }
}
