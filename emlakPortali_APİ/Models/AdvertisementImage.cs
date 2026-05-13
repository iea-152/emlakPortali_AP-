namespace emlakPortali_APİ.Models
{
    public class AdvertisementImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; } 

        // İlişki Hangi ilana aitmııı
        public int AdvertisementId { get; set; }
        public virtual Advertisement Advertisement { get; set; }
    }
}