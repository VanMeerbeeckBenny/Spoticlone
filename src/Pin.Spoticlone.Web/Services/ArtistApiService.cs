using Pin.Spoticlone.Web.ApiDtos;
using Pin.Spoticlone.Web.Interfaces;
using Pin.Spoticlone.Web.Models;
using static System.Net.WebRequestMethods;

namespace Pin.Spoticlone.Web.Services
{
    public class ArtistsApiService : IArtistService
    {
        private string baseUrl = "https://localhost:44319/api/Artists";
        HttpClient _httpClient = null;


        public ArtistsApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public Task Create(ItemResultModel<Artist> item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemResultModel<Artist>> GetAllAsync()
        {
            try
            {
                var artists = await _httpClient.GetFromJsonAsync<IEnumerable<ArtistResponseDto>>(_httpClient.BaseAddress);
                return new ItemResultModel<Artist>
                {
                    IsSucces = true,
                    Items = artists.Select(a => new Artist
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Image = a.Image,
                        AlbumsCount = a.AlbumsCount,
                        Followers = a.Followers,
                        Popularity = a.Popularity,
                        SpotifyId = a.SpotifyId,
                        Genres = a.Genres.Select(g => new Genre { 
                            Id = g.Id,
                            Name = g.Name
                        }).ToList()
                    }).ToList(),
                }; 
            }
            catch (Exception)
            {

                return new ItemResultModel<Artist> 
                {                    
                    Error = "Something went wrong!"
                };
            }
            
        }

        public Task<ItemResultModel<Artist>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ItemResultModel<Artist> item)
        {
            throw new NotImplementedException();
        }
    }
}
