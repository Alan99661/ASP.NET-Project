using VideoGameApplication.Api.Models;

namespace VideoGameApplication.Api.Contracts
{
    public interface IApiFetcher
    {
        Task<ApiGameIdResult> GetGameIds(string key, int count);
        Task<string> GetAPIGames(string key, ApiGameIdResult gameIdResult);
    }
}