namespace Pin.Spoticlone.Web.ApiDtos
{
    public class TrackResponseDto : DtoBase
    {
        public string Title { get; set; }
        public string Duration { get; set; }
        public bool Explicit { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public string AlbumName { get; set; }
        public Guid AlbumId { get; set; }
    }
}
