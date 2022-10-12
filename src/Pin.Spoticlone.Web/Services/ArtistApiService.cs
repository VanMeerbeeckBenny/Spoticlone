using Pin.Spoticlone.Web.ApiDtos;
using Pin.Spoticlone.Web.Interfaces;
using Pin.Spoticlone.Web.Models;
using static System.Net.WebRequestMethods;

namespace Pin.Spoticlone.Web.Services
{
    public class ArtistApiService : IArtistApiService
    {
        private const string BaseUrl = "https://localhost:44319/api/Artists";
        private const string BaseGenreUrl = "https://localhost:44319/api/Genres";
        HttpClient _httpClient = null;


        public ArtistApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
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

        public async Task<ItemResultModel<Artist>> GetByGenrdeIdAsync(Guid id)
        {
            try
            {
                var artists = await _httpClient.GetFromJsonAsync<IEnumerable<ArtistResponseDto>>($"{BaseGenreUrl}/{id}/artists");
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
                        Genres = a.Genres.Select(g => new Genre
                        {
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
    }
}
