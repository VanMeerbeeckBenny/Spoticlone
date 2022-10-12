namespace Pin.Spoticlone.Web.Models
{
    public class Track:BaseEntitie
    {
        public string Title { get; set; }
        public string Duration { get; set; }
        public bool Explicit { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }    
        public Guid AlbumId { get; set; }
    }
}
