using System.ComponentModel.DataAnnotations;

namespace BandAPI.Entities
{
    public class Musician
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        public List<Band> Bands { get; set; } = new List<Band>();
    }
}
