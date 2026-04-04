using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace emlakPortali_APİ.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Property> Properties { get; set; }
    }
}
