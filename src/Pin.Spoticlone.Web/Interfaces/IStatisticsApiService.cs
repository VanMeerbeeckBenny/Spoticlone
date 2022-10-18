namespace Pin.Spoticlone.Web.Models
{
    public interface IStatisticsApiService
    {
        Task<StatisticsResultModel> GetStatistics(int ammount = 5);
    }
}
