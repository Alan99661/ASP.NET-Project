using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.SmallServices;
using VideoGameApplication.Servises.ViewModels.CollectionVIewModels;

namespace VideoGameApplication.Servises.SmallServices
{
	public class GameWithStatsCreator : IGameWithStatsCreator
	{

		private readonly IGetGameStats getGameStats;
		private readonly IGameCrudOperations operations;

		public GameWithStatsCreator(IGetGameStats getGameStats, IGameCrudOperations operations)
		{
			this.getGameStats = getGameStats;
			this.operations = operations;
		}

		public GameWithStats CreateGameWithStats(string gameId)
		{
			var game = operations.GetById(gameId);
			var res = new GameWithStats()
			{
				Game = game,
				TopGenres = getGameStats.GetTopGenres(game),
				AveragePlayTimeHours = getGameStats.GetAveragePLayTime(game),
			};
			return res;
		}
	}
}
