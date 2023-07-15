using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Servises.Abstractions;
using VideoGameApplication.Servises.ViewModels.GameViewModels;
using VideoGameApplication.Servises.ViewModels.GenreViewModels;

namespace VideoGameApplication.Servises.ViewModels.CollectionVIewModels
{
	public class GameWithTopGenresAndPlayTime: GameWithStatsBase
	{
		public List<GenreViewModel> TopGenres { get; set; } 
		public float? AveragePlayTimeHours { get; set; }
	}
}
