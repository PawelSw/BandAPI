using System.ComponentModel.DataAnnotations;

namespace BandAPI.Entities
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public int DateOfRelease { get; set; }
        public Band Band { get; set; }
        public int BandId { get; set; }
    }
}
