namespace emlakPortali_APİ.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SquareMeter { get; set; }
        public string RoomCount { get; set; }
        public string Floor { get; set; }
        public int TotalFloors { get; set; }
        public string Heating { get; set; }
        public string PropertyType { get; set; } 
        public string TransactionType { get; set; } 
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
