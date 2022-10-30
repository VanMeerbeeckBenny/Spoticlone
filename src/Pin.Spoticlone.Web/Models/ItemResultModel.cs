namespace Pin.Spoticlone.Web.Models
{
    public class ItemResultModel<T> : BaseResultModel where T : BaseModel
    {     
        public IEnumerable<T> Items { get; set; }
    }
}
