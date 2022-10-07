using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Dtos.Base;

namespace Pin.Spoticlone.Web.Dtos
{
    public class ArtistResponseDto : DtoBase
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public string SpotifyId { get; set; }
        public Uri Image { get; set; }
        public ICollection<GenreResponseDto> Genres { get; set; }
        public int AlbumsCount { get; set; }
    }
}
