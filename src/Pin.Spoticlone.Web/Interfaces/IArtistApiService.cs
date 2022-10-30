using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface IArtistApiService
    {
        Task<ItemResultModel<ArtistModel>> GetAllAsync();
        Task<ItemResultModel<ArtistModel>> GetByGenrdeIdAsync(Guid id);
    }
}
