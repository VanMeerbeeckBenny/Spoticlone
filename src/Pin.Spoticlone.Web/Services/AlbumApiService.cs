﻿using Pin.Spoticlone.Web.ApiDtos;
using Pin.Spoticlone.Web.Interfaces;
using Pin.Spoticlone.Web.Models;
using System.Net.Http;

namespace Pin.Spoticlone.Web.Services
{
    public class AlbumApiService : IAlbumService
    {
        private string baseUrl = "https://localhost:44319/api/Genres";
        private HttpClient _httpClient;

        public AlbumApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
        }
        public Task Create(ItemResultModel<Album> item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemResultModel<Album>> GetAlbumsByArtistIdAsync(string artistId)
        {
            try
            {
                var albums = await _httpClient.GetFromJsonAsync<AlbumRequestDto>($"{_httpClient.BaseAddress}/{artistId}");
                return new ItemResultModel<Album>
                {
                    IsSucces = true,
                    Items = new List<Album>
                    {
                        new Album
                        {
                            Id = albums.Id,
                            Name = albums.Name,
                            ReleaseDate = albums.ReleaseDate,
                            Image = albums.Image
                        }
                    }
                };
            }
            catch (Exception)
            {

                return new ItemResultModel<Album>
                {
                    Error = "Something went wrong!"
                };
            }
        }

        public Task<ItemResultModel<Album>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ItemResultModel<Album>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(ItemResultModel<Album> item)
        {
            throw new NotImplementedException();
        }
    }
}
