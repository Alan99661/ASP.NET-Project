using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.Contracts.Other;

namespace VideoGameApplication.Servises.MicroServises
{
    public class GetGameStats : IGetGameStats
	{
		private readonly VideoGameDBContext context;

		public GetGameStats(VideoGameDBContext context)
		{
			this.context = context;
		}

		public List<Genre>? GetTopGenres(string gameid )
		{
			var game = context.Games
		.Include(s => s.Genres)
		.FirstOrDefault(s => s.Id == gameid);

			List<Genre> topGenres = game.Genres
				.SelectMany(genre => genre.Games)
				.OrderByDescending(g => g.MetacriticRating)
				.Take(10)
				.Where(g => g.Id == gameid)
				.SelectMany(g => g.Genres)
				.Distinct()
				.ToList();

			return topGenres;
		}
	}
}
