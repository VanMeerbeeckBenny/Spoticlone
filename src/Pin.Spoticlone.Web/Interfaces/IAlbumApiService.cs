using Pin.Spoticlone.Web.Models;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface IAlbumApiService
    {
        Task<ItemResultModel<AlbumModel>> GetAlbumsByArtistIdAsync(Guid artistId);
        Task<ItemResultModel<AlbumWithTracksModel>> GetAlbumsWithTracksByIdAsync(Guid artistId);
    }
}
