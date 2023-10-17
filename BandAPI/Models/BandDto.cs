namespace BandAPI.Models
{
    public class BandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DateOfFoundation { get; set; }
        public bool IsActive { get; set; }
        public string Genres { get; set; }
        public int NumberOfAlbums
        {
            get
            {
                return Albums.Count;
            }
        }
        public List<AlbumDto> Albums { get; set; } = new List<AlbumDto>();
        public int NumberOfMusicians
        {
            get
            {
                return Musicians.Count;
            }
        }
        public List<MusicianDto> Musicians { get; set; } = new List<MusicianDto>();
    }
}
