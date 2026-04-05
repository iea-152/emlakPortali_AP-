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

        public int BuildingAge { get; set; }
        public int FloorNumber { get; set; }
        public string HeatingType { get; set; }
        public bool IsFurnished { get; set; }

        public string TasinmazNo { get; set; } = string.Empty;
        public string? EIDSNumber { get; set; }
        public bool EIDSVerified { get; set; } = false;

        public bool IsApproved { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CityId { get; set; }
        public virtual City? City { get; set; }

        public int DistrictId { get; set; }
        public virtual District? District { get; set; }

        public string NeighborhoodName { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public string? AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }

        public virtual List<AdvertisementImage>? Images { get; set; } = new List<AdvertisementImage>();
        public virtual List<UserFavorite>? Favorites { get; set; } = new List<UserFavorite>();

        public virtual List<Feature> Features { get; set; } = new List<Feature>();
    }
}