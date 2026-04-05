namespace emlakPortali_APİ.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}