using System.ComponentModel.DataAnnotations;

namespace BandAPI.Models
{
    public class CreateBandDto
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public int DateOfFoundation { get; set; }
        public bool IsActive { get; set; }
        public string Genres { get; set; }
    }
}
