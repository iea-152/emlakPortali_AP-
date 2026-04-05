namespace emlakPortali_APİ.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SquareMeter { get; set; }
        public string RoomCount { get; set; }
        public string City { get; set; }

        public int BuildingAge { get; set; }
        public int FloorNumber { get; set; }
        public string HeatingType { get; set; }
        public bool IsFurnished { get; set; }

        public bool IsApproved { get; set; } = false; 
        public bool IsActive { get; set; } = true;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        // 🌟 YENİ: Fotoğraflar ve Favorilerle Bağlantı
        public virtual List<AdvertisementImage> Images { get; set; }
        public virtual List<UserFavorite> Favorites { get; set; }
    }
}