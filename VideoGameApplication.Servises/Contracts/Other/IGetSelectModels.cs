using VideoGameApplication.Servises.ViewModels.SelectModels;

namespace VideoGameApplication.Servises.Contracts.Other
{
    public interface IGetSelectModels
    {
        List<SelectModel> GetDeveloperSelectModels();
        List<SelectModel> GetGamesSelectModels();
        List<SelectModel> GetPlatformSelectModels();
        List<SelectModel> GetGenreSelectModels();
    }
}