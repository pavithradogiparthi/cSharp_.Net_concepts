using System.ComponentModel.DataAnnotations;

namespace EFCore_Loading.Models
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price{ get; set; }
        public  virtual ICollection<VillaAmenity> VillaAmenity { get; set; }
    }
}
