namespace Pin.Spoticlone.Web.ApiDtos
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
