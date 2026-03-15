using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Loading.Models
{
    public class VillaAmenity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Villa")]
        public int VillaId { get; set; }
        public virtual  Villa Villa { get; set; }
        public  required string Name { get; set; }
    }
}
