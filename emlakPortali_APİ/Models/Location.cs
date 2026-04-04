using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace emlakPortali_APİ.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string FullAddress { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual List<Property> Properties { get; set; }
    }
}
