using System.ComponentModel.DataAnnotations;

namespace BandAPI.Models
{
    public class CreateAlbumDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public int DateOfRelease { get; set; }
        public int BandId { get; set; }
    }
}
