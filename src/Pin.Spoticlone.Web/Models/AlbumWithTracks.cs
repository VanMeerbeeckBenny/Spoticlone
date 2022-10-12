namespace Pin.Spoticlone.Web.Models
{
    public class AlbumWithTracks : BaseEntitie
    {
        public Album Album { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
    }
}
