using System.ComponentModel.DataAnnotations;

namespace BandAPI.Models
{
    public class CreateMusicianDto
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
    }
}
