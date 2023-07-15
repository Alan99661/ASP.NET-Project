using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.ViewModels.GameViewModels;
using VideoGameApplication.Servises.ViewModels.GenreViewModels;

namespace VideoGameApplication.Servises.Contracts.SmallServices
{
    public interface IGetGameStats
    {
        List<GenreViewModel> GetTopGenres(GameViewModel game);
        float? GetAveragePLayTime(GameViewModel game);
    }
}