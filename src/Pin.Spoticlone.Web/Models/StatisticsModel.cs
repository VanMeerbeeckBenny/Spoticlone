using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Web.Models
{
    public class StatisticsModel
    {
        public IEnumerable<Artist> TopFollowers { get; set; }
        public IEnumerable<Artist> TopPopularities { get; set; }
        public IEnumerable<Album> TopAlbumDurations { get; set; }
        public IEnumerable<Artist> TopArtistWithMostAlbums { get; set; }
        public IEnumerable<Track> TopTrackDurations { get; set; }
        public string TotalListeningTime { get; set; }
    }
}
