using Pin.Spoticlone.Web.ApiDtos;
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
        public Task Create(ItemResultModel<AlbumModel> item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemResultModel<AlbumModel>> GetAlbumsByArtistIdAsync(Guid artistId)
        {
            try
            {
                var albums = await _httpClient.GetFromJsonAsync<ArtistWithAlbumsResponseDto>($"https://localhost:44319/api/Artists/{artistId}/albums");
                return new ItemResultModel<AlbumModel>
                {
                    IsSucces = true,
                    Items = albums.Albums.Select(a => new AlbumModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        ReleaseDate = a.ReleaseDate,
                        Image = a.Image,
                        ArtistId = a.ArtistId,
                    }).ToList(),
                };             
                
            }
            catch (Exception)
            {

                return new ItemResultModel<AlbumModel>
                {
                    Error = "Something went wrong!"
                };
            }
        }

        public async Task<ItemResultModel<AlbumWithTracksModel>> GetAlbumsWithTracksByIdAsync(Guid albumId)
        {
            try
            {
                var albumWithTracks = await _httpClient.GetFromJsonAsync<AlbumWithTracksResponseDto>($"{_httpClient.BaseAddress}/{albumId}/tracks");
                return new ItemResultModel<AlbumWithTracksModel>
                {
                    IsSucces = true,
                    Items = new List<AlbumWithTracksModel>
                    {
                        new AlbumWithTracksModel{ 
                            Album = new AlbumModel
                            {
                                Id= albumWithTracks.Album.Id,
                                Image = albumWithTracks.Album.Image,
                                Name = albumWithTracks.Album.Name,
                                ReleaseDate = albumWithTracks.Album.ReleaseDate,
                                ArtistId = albumWithTracks.Album.ArtistId,
                                NumberOfDiscs = albumWithTracks.Album.NumberOfDiscs,
                                NumberOfTracks = albumWithTracks.Album.NumberOfTracks,
                                Duration = albumWithTracks.Album.Duration
                            },
                            Tracks = albumWithTracks.Tracks.Select(t => new TrackModel
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

                return new ItemResultModel<AlbumWithTracksModel>
                {
                    Error = "Something went wrong!"
                };
            }
        }
    }
}
