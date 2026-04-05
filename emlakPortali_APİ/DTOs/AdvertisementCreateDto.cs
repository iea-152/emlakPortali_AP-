namespace emlakPortali_APİ.DTOs
{
    public class AdvertisementCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SquareMeter { get; set; }
        public string RoomCount { get; set; }
        public int BuildingAge { get; set; }
        public int FloorNumber { get; set; }
        public string HeatingType { get; set; }
        public bool IsFurnished { get; set; }
        public string TasinmazNo { get; set; } // EİDS için

        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string NeighborhoodName { get; set; }
        public int CategoryId { get; set; }
    }
}