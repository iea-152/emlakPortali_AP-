namespace emlakPortali_APİ.DTOs
{
    public class AdvertisementDetailDto
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
        public string TasinmazNo { get; set; }

        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string NeighborhoodName { get; set; }
        public string CategoryName { get; set; }
        public string SellerFullName { get; set; }

        public List<string> ImageUrls { get; set; }
        public List<string> Features { get; set; } 
        public DateTime CreatedDate { get; set; }
    }
}