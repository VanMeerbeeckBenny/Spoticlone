﻿using Pin.Spoticlone.Web.ApiDtos;
using Pin.Spoticlone.Web.Interfaces;
using Pin.Spoticlone.Web.Models;
using System.Net.Http;

namespace Pin.Spoticlone.Web.Services
{
    public class AlbumApiService : IAlbumApiService
    {
        private string baseUrl = "https://localhost:44319/api/Albums";
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

        public async Task<ItemResultModel<Album>> GetAlbumsByArtistIdAsync(Guid artistId)
        {
            try
            {
                var albums = await _httpClient.GetFromJsonAsync<ArtistWithAlbumsResponseDto>($"https://localhost:44319/api/Artists/{artistId}/albums");
                return new ItemResultModel<Album>
                {
                    IsSucces = true,
                    Items = albums.Albums.Select(a => new Album
                    {
                        Id = a.Id,
                        Name = a.Name,
                        ReleaseDate = a.ReleaseDate,
                        Image = a.Image
                    }).ToList(),
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

        public async Task<ItemResultModel<AlbumWithTracks>> GetAlbumsWithTracksByIdAsync(Guid albumId)
        {
            try
            {
                var albumWithTracks = await _httpClient.GetFromJsonAsync<AlbumWithTracksResponseDto>($"{_httpClient.BaseAddress}/{albumId}/tracks");
                return new ItemResultModel<AlbumWithTracks>
                {
                    IsSucces = true,
                    Items = new List<AlbumWithTracks>
                    {
                        new AlbumWithTracks{ 
                            Album = new Album
                            {
                                Id= albumWithTracks.Album.Id,
                                Image = albumWithTracks.Album.Image,
                                Name = albumWithTracks.Album.Name,
                                ReleaseDate = albumWithTracks.Album.ReleaseDate,
                            },
                            Tracks = albumWithTracks.Tracks.Select(t => new Track
                            {
                                Id = t.Id,
                                AlbumId = t.AlbumId,
                                DiscNumber = t.DiscNumber,
                                Explicit = t.Explicit,
                                Duration = t.Duration,
                                Title = t.Title,
                                TrackNumber = t.TrackNumber

                            })
                            .OrderBy(t => t.DiscNumber)
                            .ThenBy(t => t.TrackNumber)
                            .ToList()
                    }
                   }
                };

            }
            catch (Exception)
            {

                return new ItemResultModel<AlbumWithTracks>
                {
                    Error = "Something went wrong!"
                };
            }
        }
    }
}
