using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using emlakPortali_APİ.Models;

namespace emlakPortali_APİ.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AdvertisementImage> AdvertisementImages { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFavorite>()
                .HasOne(f => f.AppUser)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserFavorite>()
                .HasOne(f => f.Advertisement)
                .WithMany(a => a.Favorites)
                .HasForeignKey(f => f.AdvertisementId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}