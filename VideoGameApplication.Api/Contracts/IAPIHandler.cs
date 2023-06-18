using VideoGameApplication.Api.Models;

namespace VideoGameApplication.Api.Contracts
{
    public interface IAPIHandler
    {
        Task<APIGameIdResult> GetGameIds(string key, int count);
        Task<string> GetAPIGames(string key, APIGameIdResult gameIdResult);
    }
}