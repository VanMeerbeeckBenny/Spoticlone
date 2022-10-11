using Pin.Spoticlone.Web.Interfaces;
using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Services
{
    public class GenreApiService : IGenreService
    {
        private string baseUrl = "https://localhost:44319/api/Genres";
        HttpClient _httpClient = null;


        public GenreApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
        }
        public Task Create(ItemResultModel<Genre> item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemResultModel<Genre>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemResultModel<Genre>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ItemResultModel<Genre> item)
        {
            throw new NotImplementedException();
        }
    }
}
