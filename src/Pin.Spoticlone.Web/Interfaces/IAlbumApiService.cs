using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface IAlbumApiService
    {
        Task<ItemResultModel<Album>> GetAlbumsByArtistIdAsync(Guid artistId);
    }
}
