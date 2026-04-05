namespace emlakPortali_APİ.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Advertisement> Advertisements { get; set; } = new List<Advertisement>();
    }
}