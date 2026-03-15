using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaNumbercreateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string Specialdetails { get; set; }
    }
}
