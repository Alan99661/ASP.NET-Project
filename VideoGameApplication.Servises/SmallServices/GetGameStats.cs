using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.Contracts.SmallServices;
using VideoGameApplication.Servises.ViewModels.GameViewModels;
using VideoGameApplication.Servises.ViewModels.GenreViewModels;

namespace VideoGameApplication.Servises.MicroServises
{
    public class GetGameStats : IGetGameStats
	{
		//private readonly VideoGameDBContext context;
		private readonly IMapper mapper;

		public GetGameStats(IMapper mapper)
		{
			//this.context = context;
			this.mapper = mapper;
		}

		public float? GetAveragePLayTime(GameViewModel game)
		{
			float? averatePlayTime = game.Reviews.Average(r => r.PlayTimeHours);
			if (averatePlayTime != null)
			{
			return MathF.Round((float)averatePlayTime , 1);
			}
			return averatePlayTime;
		}

		public List<GenreViewModel>? GetTopGenres(GameViewModel game )
		{
			List<Genre> topGenres = game.Genres
				.SelectMany(genre => genre.Games)
				.OrderByDescending(g => g.MetacriticRating)
				.Take(10)
				.Where(g => g.Id == game.Id)
				.SelectMany(g => g.Genres)
				.Distinct()
				.ToList();

			return mapper.Map<List<GenreViewModel>>(topGenres);
		}
	}
}
