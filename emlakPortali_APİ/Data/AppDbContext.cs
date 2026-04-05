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
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Feature> Features { get; set; }

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

            builder.Entity<Advertisement>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Advertisement>()
                .HasOne(a => a.District)
                .WithMany()
                .HasForeignKey(a => a.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>().HasData(new Category { Id = 1, Name = "Konut", Description = "Konut İlanları" });
            builder.Entity<City>().HasData(new City { Id = 1, Name = "Denizli" });
            builder.Entity<District>().HasData(new District { Id = 1, Name = "Merkezefendi", CityId = 1 });
            builder.Entity<Neighborhood>().HasData(new Neighborhood { Id = 1, Name = "Çamlaraltı", DistrictId = 1 });

            builder.Entity<Feature>().HasData(
                new Feature { Id = 1, Name = "Asansör" },
                new Feature { Id = 2, Name = "Otopark" },
                new Feature { Id = 3, Name = "Havuz" },
                new Feature { Id = 4, Name = "Güvenlik" },
                new Feature { Id = 5, Name = "Akıllı Ev Sistemi" }
            );
        }
    }
}