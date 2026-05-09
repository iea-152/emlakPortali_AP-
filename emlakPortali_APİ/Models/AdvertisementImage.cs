namespace emlakPortali_APİ.Models
{
    public class AdvertisementImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; } 
        public int AdvertisementId { get; set; }
        public virtual Advertisement Advertisement { get; set; }
    }
}