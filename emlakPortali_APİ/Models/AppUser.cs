using Microsoft.AspNetCore.Identity;

namespace emlakPortali_APİ.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public virtual List<UserFavorite> Favorites { get; set; }  
        public virtual List<Advertisement> Advertisements { get; set; }
    }
}