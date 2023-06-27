using VideoGameApplication.Api.Models;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Api.Contracts
{
    public interface IApiListChecker
    {
        List<Developer> CheckDeveloperList(List<ApiModel> apidevs);
        List<Genre> CheckGenreList(List<ApiModel> apigenres);
        List<Platform> CheckPlatformList(List<ApiPlatforms> apiPlatforms);
        List<Screenshot> CheckScreenshotList(List<ApiScreenshot> apiscreenshots);
    }
}