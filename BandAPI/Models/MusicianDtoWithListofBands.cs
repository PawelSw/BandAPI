using BandAPI.Entities;

namespace BandAPI.Models
{
    public class MusicianDtoWithListofBands
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public List<BandDtoOnlyName> Bands { get; set; } = new List<BandDtoOnlyName>();
    }
}
