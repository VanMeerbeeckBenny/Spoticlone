using Pin.Spoticlone.Web.ApiDtos;
using Pin.Spoticlone.Web.Interfaces;
using Pin.Spoticlone.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
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
        public async Task<ItemResultModel<TrackModel>> AddAsync(string title,string duration,bool isExplicit,int trackNumber,int discNumber,Guid albumId)
        {
            try
            {
                var trackToAdd = new TrackRequestDto
                {
                    Id = Guid.NewGuid(),
                    Name = title,
                    DurationMs = ((int)TimeSpan.Parse($"00:{duration}").TotalMilliseconds),
                    Explicit = isExplicit,
                    DiscNumber = discNumber,
                    AlbumId = albumId,
                    TrackNumber = trackNumber,
                };

                await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress.ToString(), trackToAdd);
                return new ItemResultModel<TrackModel> {IsSucces =true };
            }
            catch (Exception)
            {

                return new ItemResultModel<TrackModel>
                {
                    Error = "Update failed!"
                };
            }
        }

        public async Task<ItemResultModel<TrackModel>> UpdateAsync(string title, string duration, bool isExplicit, int trackNumber, int discNumber,Guid id, Guid albumId)
        {
            try
            {
                var result = await GetTrackById(id);
                if (!result.IsSucces) return new ItemResultModel<TrackModel> { Error = result.Error };
                
                var trackToAdd = new TrackRequestDto
                {       
                    Id = id,
                    Name = title,
                    DurationMs = ((int)TimeSpan.Parse($"00:{duration}").TotalMilliseconds),
                    Explicit = isExplicit,
                    DiscNumber = discNumber,
                    AlbumId = albumId,
                    TrackNumber = trackNumber,
                };

                var httpResult = await _httpClient.PutAsJsonAsync(_httpClient.BaseAddress.ToString(), trackToAdd);
                if (httpResult.StatusCode != HttpStatusCode.OK)
                {
                    return new ItemResultModel<TrackModel>
                    {
                        Error = await httpResult.Content.ReadAsStringAsync(),
                    };
                }
                return new ItemResultModel<TrackModel> { IsSucces = true };
            }
            catch (Exception)
            {

                return new ItemResultModel<TrackModel>
                {
                    Error = "Update failed!"
                };
            }
        }

        public async Task<ItemResultModel<TrackModel>> DeleteAsync(Guid id)
        {            
            try
            {                
                var result = await _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/{id}");
                if (result.StatusCode != HttpStatusCode.OK) 
                {
                    return new ItemResultModel<TrackModel>
                    {
                        Error = await result.Content.ReadAsStringAsync(),
                    };
                } 
                return new ItemResultModel<TrackModel> { IsSucces = true };
            }
            catch (Exception)
            {

                return new ItemResultModel<TrackModel> { Error="Nothing is deleted!" };
            }
        }

        public async Task<ItemResultModel<TrackModel>> GetTrackById(Guid id)
        {
            try
            {               
                var trackDto  = await _httpClient.GetFromJsonAsync<TrackResponseDto>($"{_httpClient.BaseAddress}/{id}");
                return new ItemResultModel<TrackModel>
                {
                    Items = new List<TrackModel>
                    {
                        new TrackModel
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

                return new ItemResultModel<TrackModel>
                {
                    Error = "Something went wrong!"
                };
            }
        }

    


    }
}
