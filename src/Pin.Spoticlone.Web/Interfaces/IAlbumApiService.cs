using Pin.Spoticlone.Web.Models;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface IAlbumApiService
    {
        Task<ItemResultModel<Album>> GetAlbumsByArtistIdAsync(Guid artistId);
        Task<ItemResultModel<AlbumWithTracks>> GetAlbumsWithTracksByIdAsync(Guid artistId);
    }
}
