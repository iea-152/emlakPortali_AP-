namespace emlakPortali_APİ.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual List<Neighborhood> Neighborhoods { get; set; }
    }
}