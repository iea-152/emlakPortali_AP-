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

        //ilişkiler
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}