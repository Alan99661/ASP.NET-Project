using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.Contracts.SmallServices;

namespace VideoGameApplication.Servises.SmallServices
{
	public class GameSearchFilters : IGameSearchFilters
	{
		private readonly VideoGameDBContext context;

		public GameSearchFilters(VideoGameDBContext dbContext)
		{
			context = dbContext;
		}

		public IQueryable<Game> FilterByDeveloper(IQueryable<Game> games, string developerId)
		{
			return games.Where(s => s.Developers.Any(d => d.Id == developerId));
		}

		public IQueryable<Game> FilterByGenre(IQueryable<Game> games, string genreId)
		{
			return games.Where(s => s.Genres.Any(g => g.Id == genreId));
		}

		public IQueryable<Game> FilterByName(IQueryable<Game> games, string name)
		{
			return games.Where(s => s.Name.Contains(name));
		}

		public IQueryable<Game> FilterByPlatform(IQueryable<Game> games, string platformId)
		{
			return games.Where(s => s.Platforms.Any(p => p.Id == platformId));
		}

		public IQueryable<Game> FilterByRating(IQueryable<Game> games, int? targetRating, int? modifier)
		{
			switch (modifier)
			{
				case 1:
					return games.Where(s => s.MetacriticRating < targetRating);
				case 2:
					return games.Where(s => s.MetacriticRating == targetRating);
				case 3:
					return games.Where(s => s.MetacriticRating > targetRating);
			}
			return games;
		}

		public IQueryable<Game> FilterByRelease(IQueryable<Game> games, DateTime? releaseDate, int? modifier)
		{
			switch (modifier)
			{
				case 1:
					return games.Where(s => s.ReleaseDate < releaseDate);
				case 2:
					return games.Where(s => s.ReleaseDate == releaseDate);
				case 3:
					return games.Where(s => s.ReleaseDate > releaseDate);
			}
			return games;
		}
	}
}
