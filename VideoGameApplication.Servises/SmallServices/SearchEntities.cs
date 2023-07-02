using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.Contracts.SmallServices;
using VideoGameApplication.Servises.ViewModels.GameViewModels;

namespace VideoGameApplication.Servises.MicroServises
{
    public class SearchEntities : ISearchEntities
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;
        private readonly IGameSearchFilters filters;

        public SearchEntities(VideoGameDBContext context, IMapper mapper , IGameSearchFilters filters)
        {
            this.context = context;
            this.mapper = mapper;
            this.filters = filters;
        }

        public async Task<List<GameViewModel>?> SearchGames(GameSearchModel searchModel)
        {
            IQueryable<Game> gamesQuery = context.Games.Select(s => s);

            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                gamesQuery = filters.FilterByName(gamesQuery, searchModel.Name);
            }

            if (!string.IsNullOrEmpty(searchModel.GenreId))
            {
                gamesQuery = filters.FilterByGenre(gamesQuery, searchModel.GenreId);
            }

            if (!string.IsNullOrEmpty(searchModel.DeveloperId))
            {
                gamesQuery = filters.FilterByDeveloper(gamesQuery, searchModel.DeveloperId);
            }

            if (!string.IsNullOrEmpty(searchModel.PlatformId))
            {
                gamesQuery = filters.FilterByPlatform(gamesQuery, searchModel.PlatformId);
            }

            if (searchModel.ReleaseDate != null && searchModel.ReleaseParam != null)
            {
                gamesQuery = filters.FilterByRelease(gamesQuery, searchModel.ReleaseDate, searchModel.ReleaseParam);
            }

            if (searchModel.MetacriticRating != null && searchModel.MetacriticParam != null)
            {
                gamesQuery = filters.FilterByRating(gamesQuery, searchModel.MetacriticRating, searchModel.MetacriticParam);
            }

            List<Game> games = await gamesQuery.ToListAsync();
            return mapper.Map<List<GameViewModel>>(games);
        }

    }

}

