namespace Pin.Spoticlone.Web.Models
{
    public class ItemResultModel<T>where T : BaseEntitie
    {
        public bool IsSucces { get; set; }
        public string Error { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
