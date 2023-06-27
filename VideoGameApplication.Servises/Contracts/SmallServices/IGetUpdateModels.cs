using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;
using VideoGameApplication.Servises.ViewModels.GameViewModels;
using VideoGameApplication.Servises.ViewModels.GenreViewModels;
using VideoGameApplication.Servises.ViewModels.PlatformViewModels;
using VideoGameApplication.Servises.ViewModels.ReviewViewModels;
using VideoGameApplication.Servises.ViewModels.ScreenshotViewModels;

namespace VideoGameApplication.Servises.Contracts.SmallServices
{
    public interface IGetUpdateModels
    {
        DeveloperUpdateModel GetDevUpdateModel(string id);
        GameUpdateModel GetGameUpdateModel(string id);
        PlatformUpdateModel GetPlatformUpdateModel(string id);
        ReviewUpdateModel GetReviewUpdateModel(string id);
        GenreUpdateModel GetGenreUpdateModel(string id);
        ScreenshotUpdateModel GetScreenshotUpdateModel(string id);
    }
}