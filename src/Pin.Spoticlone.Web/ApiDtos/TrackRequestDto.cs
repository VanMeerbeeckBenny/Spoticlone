namespace Pin.Spoticlone.Web.ApiDtos
{
    public class TrackRequestDto : DtoBase
    {
        public string Name { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public Guid AlbumId { get; set; }
    }
}
