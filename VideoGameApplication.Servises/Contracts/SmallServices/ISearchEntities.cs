using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.ViewModels.GameViewModels;

namespace VideoGameApplication.Servises.Contracts.SmallServices
{
    public interface ISearchEntities
    {
        Task<List<GameViewModel>?> SearchGames(GameSearchModel searchModel);
    }
}