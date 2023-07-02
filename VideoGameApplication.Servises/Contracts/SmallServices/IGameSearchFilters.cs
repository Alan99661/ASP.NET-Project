using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Servises.Contracts.SmallServices
{
	public interface IGameSearchFilters
	{
		public IQueryable<Game> FilterByName(IQueryable<Game> games, string name);
		public IQueryable<Game> FilterByGenre(IQueryable<Game> games, string genreId);
		public IQueryable<Game> FilterByPlatform(IQueryable<Game> games, string platformId);
		public IQueryable<Game> FilterByDeveloper(IQueryable<Game> games, string developerId);
		public IQueryable<Game> FilterByRelease(IQueryable<Game> games, DateTime? releaseDate, int? modifier);
		public IQueryable<Game> FilterByRating(IQueryable<Game> games, int? targetRating, int? modifier);
	}
}
