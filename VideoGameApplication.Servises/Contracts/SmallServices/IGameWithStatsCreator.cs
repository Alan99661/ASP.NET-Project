using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Servises.Abstractions;
using VideoGameApplication.Servises.ViewModels.CollectionVIewModels;

namespace VideoGameApplication.Servises.Contracts.SmallServices
{
	public interface IGameWithStatsCreator
	{
		public GameWithStats CreateGameWithStats(string gameId);
	}
}
