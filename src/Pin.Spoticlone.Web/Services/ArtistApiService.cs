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

        public Task Create(Artist item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            var artists = await _httpClient.GetFromJsonAsync<IEnumerable<ArtistResponseDto>>("https://localhost:44319/api/Artists");
            return artists.Select(a => new Artist
            {
                Id = a.Id,
                Name = a.Name,
                Followers = a.Followers,
                Popularity = a.Popularity,
                Image = a.Image,
            });
        }

        public Task<Artist> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Artist item)
        {
            throw new NotImplementedException();
        }
    }
}
