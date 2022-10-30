namespace Pin.Spoticlone.Web.Models
{
    public class AlbumWithTracksModel : BaseModel
    {
        public AlbumModel Album { get; set; }
        public IEnumerable<TrackModel> Tracks { get; set; }
    }
}
