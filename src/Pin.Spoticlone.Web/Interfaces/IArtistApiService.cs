using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface IArtistApiService
    {
        Task<ItemResultModel<Artist>> GetAllAsync();
    }
}
