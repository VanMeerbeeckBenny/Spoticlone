using System.ComponentModel.DataAnnotations;

namespace Pin.Spoticlone.Web.Models
{
    public class Track:BaseEntitie
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public bool Explicit { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }    
        public Guid AlbumId { get; set; }
    }
}
