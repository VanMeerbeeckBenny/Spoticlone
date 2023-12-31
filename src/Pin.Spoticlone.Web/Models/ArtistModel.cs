﻿namespace Pin.Spoticlone.Web.Models
{
    public class ArtistModel : BaseModel
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }      
        public string SpotifyId { get; set; }
        public Uri Image { get; set; }
        public int AlbumsCount { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; }
    }
}
