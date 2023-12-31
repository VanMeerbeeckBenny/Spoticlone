﻿namespace Pin.Spoticlone.Web.ApiDtos
{
    public class AlbumResponseDto : DtoBase
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri Image { get; set; }
        public Guid ArtistId { get; set; }
        public int NumberOfTracks { get; set; }
        public int NumberOfDiscs { get; set; }
        public string Duration { get; set; }
    }
}
