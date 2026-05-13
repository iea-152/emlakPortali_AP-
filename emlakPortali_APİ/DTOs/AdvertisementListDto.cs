namespace emlakPortali_APİ.DTOs
{
    public class AdvertisementListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string RoomCount { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string CategoryName { get; set; }
        public bool IsApproved { get; set; }
        public string FirstImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}