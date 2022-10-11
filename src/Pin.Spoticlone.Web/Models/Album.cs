namespace Pin.Spoticlone.Web.Models
{
    public class Album:BaseEntitie
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri Image { get; set; }

    }
}
