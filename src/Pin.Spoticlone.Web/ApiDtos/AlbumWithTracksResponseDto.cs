
namespace Pin.Spoticlone.Web.ApiDtos
{
    public class AlbumWithTracksResponseDto
    {
        public AlbumResponseDto Album { get; set; }
        public IEnumerable<TrackResponseDto> Tracks { get; set; }
    }
}
