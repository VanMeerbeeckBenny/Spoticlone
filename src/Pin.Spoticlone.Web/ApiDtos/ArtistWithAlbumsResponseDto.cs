using System.Collections.Generic;

namespace Pin.Spoticlone.Web.ApiDtos
{
    public class ArtistWithAlbumsResponseDto
    {
        public ArtistResponseDto Artist { get; set; }
        public IEnumerable<AlbumResponseDto> Albums { get; set; }
    }
}