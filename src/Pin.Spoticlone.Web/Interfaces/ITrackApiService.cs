using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface ITrackApiService
    {
        Task<ItemResultModel<Track>> GetTrackById(Guid id);
        Task<ItemResultModel<Track>> UpdateAsync(string title, string duration, bool isExplicit, int trackNumber, int discNumber,Guid id, Guid albumId);
        Task<ItemResultModel<Track>> AddAsync(string title, string duration, bool isExplicit, int trackNumber, int discNumber, Guid albumId);
        Task<ItemResultModel<Track>> DeleteAsync(Guid id);

    }
}
