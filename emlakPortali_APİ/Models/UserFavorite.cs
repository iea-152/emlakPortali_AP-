namespace emlakPortali_APİ.Models
{
    public class UserFavorite
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int AdvertisementId { get; set; }
        public virtual Advertisement Advertisement { get; set; }
    }
}