using System.ComponentModel.DataAnnotations;

namespace Pin.Spoticlone.Web.Models
{
    public class TrackModel:BaseModel
    {
        [Required]
        [MaxLength(100,ErrorMessage ="{0} can not be longer then {1}")]
        [MinLength(2, ErrorMessage = "{0} can not be longer then {1}")]
        public string Title { get; set; }
        [Required]
        public string Duration { get; set; }        
        public bool Explicit { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int TrackNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int DiscNumber { get; set; }    
        public Guid AlbumId { get; set; }
    }
}
