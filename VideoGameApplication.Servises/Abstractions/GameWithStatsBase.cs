using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.ViewModels.GameViewModels;

namespace VideoGameApplication.Servises.Abstractions
{
	public abstract class GameWithStatsBase
	{
		public GameViewModel Game { get; set; }
	}
}
