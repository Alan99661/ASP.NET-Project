using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Servises.Contracts.Other
{
    public interface IGetGameStats
    {
        List<Genre> GetTopGenres(string id);
    }
}