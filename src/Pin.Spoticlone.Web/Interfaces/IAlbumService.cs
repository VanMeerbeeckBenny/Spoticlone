using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface IAlbumService : ICRUDService<Album>
    {
        Task<ItemResultModel<Album>> GetAlbumsByArtistIdAsync(string artistId);
    }
}
