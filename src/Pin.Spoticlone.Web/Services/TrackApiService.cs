using Pin.Spoticlone.Web.ApiDtos;
using Pin.Spoticlone.Web.Interfaces;
using Pin.Spoticlone.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace Pin.Spoticlone.Web.Services
{
    public class TrackApiService : ITrackApiService
    {
        HttpClient _httpClient;
        private const string BaseTrackUrl = "https://localhost:44319/api/Tracks";
        public TrackApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseTrackUrl);
        }
        public async Task<ItemResultModel<Track>> AddAsync(string title,string duration,bool isExplicit,int trackNumber,int discNumber,Guid albumId)
        {
            try
            {
                var trackToAdd = new TrackRequestDto
                {
                    Id = Guid.NewGuid(),
                    Name = title,
                    DurationMs = 0,
                    Explicit = isExplicit,
                    DiscNumber = discNumber,
                    AlbumId = albumId,
                    TrackNumber = trackNumber,
                };

                await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress.ToString(), trackToAdd);
                return new ItemResultModel<Track> {IsSucces =true };
            }
            catch (Exception)
            {

                return new ItemResultModel<Track>
                {
                    Error = "Update failed!"
                };
            }
        }

        public Task<ItemResultModel<Track>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemResultModel<Track>> GetTrackById(Guid id)
        {
            try
            {               
                var trackDto  = await _httpClient.GetFromJsonAsync<TrackResponseDto>($"{_httpClient.BaseAddress}/id");
                return new ItemResultModel<Track>
                {
                    Items = new List<Track>
                    {
                        new Track
                        {
                            Id = trackDto.Id,
                            Title = trackDto.Title,
                            TrackNumber = trackDto.TrackNumber,
                            DiscNumber = trackDto.DiscNumber,
                            Explicit = trackDto.Explicit,
                            Duration = trackDto.Duration,
                            AlbumId = trackDto.AlbumId,
                        }
                    },
                    IsSucces = true 
                };
            }
            catch (Exception)
            {

                return new ItemResultModel<Track>
                {
                    Error = "Something went wrong!"
                };
            }
        }

        public Task<ItemResultModel<Track>> UpdateAsync(string Title, string Duration, bool Explicit, int TrackNumber, int DiscNumber, Guid id, Guid albumId)
        {
            throw new NotImplementedException();
        }


    }
}
