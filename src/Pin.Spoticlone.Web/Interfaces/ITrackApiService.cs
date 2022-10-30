using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Interfaces
{
    public interface ITrackApiService
    {
        Task<ItemResultModel<TrackModel>> GetTrackById(Guid id);
        Task<ItemResultModel<TrackModel>> UpdateAsync(string title, string duration, bool isExplicit, int trackNumber, int discNumber,Guid id, Guid albumId);
        Task<ItemResultModel<TrackModel>> AddAsync(string title, string duration, bool isExplicit, int trackNumber, int discNumber, Guid albumId);
        Task<ItemResultModel<TrackModel>> DeleteAsync(Guid id);

    }
}
