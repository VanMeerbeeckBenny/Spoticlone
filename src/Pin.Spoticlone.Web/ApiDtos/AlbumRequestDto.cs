using Pin.Spoticlone.Core.ApiDtos;
using System;

namespace Pin.Spoticlone.Web.ApiDtos
{
    public class AlbumRequestDto : DtoBase
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri Image { get; set; }
        public Guid ArtistId { get; set; }
    }
}
