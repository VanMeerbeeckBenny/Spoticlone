using Pin.Spoticlone.Web.ApiDtos;
using Pin.Spoticlone.Web.Interfaces;
using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Services
{
    public class ArtistApiService : ICRUDService<Artist>
    {
        HttpClient _httpClient = null;


        public ArtistApiService()
        {
            _httpClient = new HttpClient();
        }

        public Task Create(ItemResultModel<Artist> item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemResultModel<Artist>> GetAllAsync()
        {
            try
            {
                var artists = await _httpClient.GetFromJsonAsync<IEnumerable<ArtistResponseDto>>("https://localhost:44319/api/Artists");
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

        public Task<ItemResultModel<Artist>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ItemResultModel<Artist> item)
        {
            throw new NotImplementedException();
        }
    }
}
