using VideoGameApplication.Api.Models;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Api.Contracts
{
    public interface IAPIListChecker
    {
        List<Developer> GetDeveloperList(List<APIModel> apidevs);
        List<Genre> GetGenreList(List<APIModel> apigenres);
        List<Platform> GetPlatformList(List<APIPlatforms> apiPlatforms);
        List<Screenshot> GetScreenshotList(List<APIScreenshot> apiscreenshots);
    }
}