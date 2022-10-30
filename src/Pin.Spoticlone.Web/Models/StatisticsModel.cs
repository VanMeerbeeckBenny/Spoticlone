using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Web.Models
{
    public class StatisticsModel
    {
        public IEnumerable<ArtistModel> TopFollowers { get; set; }
        public IEnumerable<ArtistModel> TopPopularities { get; set; }
        public IEnumerable<AlbumModel> TopAlbumDurations { get; set; }
        public IEnumerable<ArtistModel> TopArtistWithMostAlbums { get; set; }
        public IEnumerable<TrackModel> TopTrackDurations { get; set; }
        public string TotalListeningTime { get; set; }
    }
}
