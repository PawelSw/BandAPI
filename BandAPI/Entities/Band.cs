using System.ComponentModel.DataAnnotations;

namespace BandAPI.Entities
{
    public class Band
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(4)]
        public int DateOfFoundation { get; set; }

        public bool IsActive { get; set; }

        public virtual Description Description { get; set; }
        public int DescriptionId { get; set; }
        public virtual List<Album> Albums { get; set; } = new List<Album>();

        public virtual List<Musician> Musicians { get; set; } = new List<Musician>();
    }
}
