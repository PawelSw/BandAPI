namespace BandAPI.Entities
{
    public class Description
    {
        public int Id { get; set; }

        public string Genres { get; set; }
        public virtual Band Band { get; set; }
    }
}
