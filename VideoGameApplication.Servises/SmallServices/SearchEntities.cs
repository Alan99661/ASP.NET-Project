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

        public SearchEntities(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GameViewModel>?> SearchGames(GameSearchModel searchModel)
        {
            IQueryable<Game> gamesQuery = context.Games.Select(s => s);

            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                gamesQuery = gamesQuery.Where(s => s.Name.Contains(searchModel.Name));
            }

            if (!string.IsNullOrEmpty(searchModel.GenreId))
            {
                gamesQuery = gamesQuery.Where(s => s.Genres.Any(g => g.Id == searchModel.GenreId));
            }

            if (!string.IsNullOrEmpty(searchModel.DeveloperId))
            {
                gamesQuery = gamesQuery.Where(s => s.Developers.Any(d => d.Id == searchModel.DeveloperId));
            }

            if (!string.IsNullOrEmpty(searchModel.PlatformId))
            {
                gamesQuery = gamesQuery.Where(s => s.Platforms.Any(p => p.Id == searchModel.PlatformId));
            }

            if (searchModel.ReleaseDate != null && searchModel.ReleaseParam != null)
            {
                switch (searchModel.ReleaseParam)
                {
                    case 1:
                        gamesQuery = gamesQuery.Where(s => s.ReleaseDate < searchModel.ReleaseDate);
                        break;
                    case 2:
                        gamesQuery = gamesQuery.Where(s => s.ReleaseDate == searchModel.ReleaseDate);
                        break;
                    case 3:
                        gamesQuery = gamesQuery.Where(s => s.ReleaseDate > searchModel.ReleaseDate);
                        break;
                }
            }

            if (searchModel.MetacriticRating != null && searchModel.MetacriticParam != null)
            {
                switch (searchModel.MetacriticParam)
                {
                    case 1:
                        gamesQuery = gamesQuery.Where(s => s.MetacriticRating < searchModel.MetacriticRating);
                        break;
                    case 2:
                        gamesQuery = gamesQuery.Where(s => s.MetacriticRating == searchModel.MetacriticRating);
                        break;
                    case 3:
                        gamesQuery = gamesQuery.Where(s => s.MetacriticRating > searchModel.MetacriticRating);
                        break;
                }
            }

            List<Game> games = await gamesQuery.ToListAsync();
            return mapper.Map<List<GameViewModel>>(games);
        }

    }

}

