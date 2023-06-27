using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.ViewModels.GenreViewModels;

namespace VideoGameApplication.Servises.Contracts.SmallServices
{
    public interface IGetGameStats
    {
        List<GenreViewModel> GetTopGenres(string id);
    }
}