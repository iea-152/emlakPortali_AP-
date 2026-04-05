namespace emlakPortali_APİ.DTOs
{
    public class AdvertisementFilterDto
    {
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? RoomCount { get; set; }
    }
}