using System.ComponentModel.DataAnnotations;

namespace BandAPI.Models
{
    public class UpdateBandDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int DateOfFoundation { get; set; }
    }
}
