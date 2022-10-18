using Pin.Spoticlone.Web.ApiDtos;
using Pin.Spoticlone.Web.Models;

namespace Pin.Spoticlone.Web.Services
{
    public class StatisticsApiService : IStatisticsApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseGenreUrl = "https://localhost:44319/api/Statistics";

        public StatisticsApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseGenreUrl);
        }

        public async Task<StatisticsResultModel> GetStatistics(int amount)
        {
            
            try
            {
                var statistics = await _httpClient.GetFromJsonAsync<StatisticsResponseDto>($"{_httpClient.BaseAddress}/{amount}");
                return new StatisticsResultModel
                {
                    IsSucces = true,
                    statistics = new StatisticsModel
                    {
                        TopFollowers = statistics.TopFollowers.Select(t => new Artist
                        {
                            Id = t.Id,
                            Name = t.Name,
                            Image = t.Image,
                            Popularity = t.Popularity,
                            AlbumsCount = t.AlbumsCount,
                            Followers = t.Followers,
                            Genres = t.Genres.Select(g => new Genre
                            {
                                Id = g.Id,
                                Name = g.Name,
                            }).ToList(),
                            
                        }).ToList(),
                        TopAlbumDurations =  statistics.TopAlbumDurations.Select(a => new Album
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Image = a.Image,
                            ReleaseDate = a.ReleaseDate,
                            ArtistId = a.ArtistId,
                            Duration = a.Duration,
                            NumberOfDiscs = a.NumberOfDiscs,
                            NumberOfTracks = a.NumberOfTracks
                        }).ToList(),
                        TopArtistWithMostAlbums = statistics.TopArtistWithMostAlbums.Select(a => new Artist
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Image = a.Image,
                            Popularity = a.Popularity,
                            AlbumsCount = a.AlbumsCount,
                            Followers = a.Followers,
                            Genres = a.Genres.Select(g => new Genre
                            {
                                Id = g.Id,
                                Name = g.Name,
                            }).ToList(),
                        }),
                        TopPopularities = statistics.TopPopularities.Select(a => new Artist
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Image = a.Image,
                            Popularity = a.Popularity,
                            AlbumsCount = a.AlbumsCount,
                            Followers = a.Followers,
                            Genres = a.Genres.Select(g => new Genre
                            {
                                Id = g.Id,
                                Name = g.Name,
                            }).ToList(),
                        }),
                        TopTrackDurations = statistics.TopTrackDurations.Select(t => new Track
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Explicit = t.Explicit,
                            Duration = t.Duration,
                            AlbumId = t.AlbumId,
                            DiscNumber = t.DiscNumber,
                            TrackNumber = t.TrackNumber
                        }),
                        TotalListeningTime = statistics.TotalListeningTime
                    },         
                    
                };

            }
            catch (Exception)
            {

                return new StatisticsResultModel { Error = "Something went wrong!!" };                
            }

        }
    }
}
