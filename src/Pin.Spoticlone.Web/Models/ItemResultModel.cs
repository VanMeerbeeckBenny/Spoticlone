namespace Pin.Spoticlone.Web.Models
{
    public class ItemResultModel<T> : BaseResultModel where T : BaseEntitie
    {     
        public IEnumerable<T> Items { get; set; }
    }
}
