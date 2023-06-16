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

		public List<Genre> GetTopGenres(string gameid )
		{
			var game = context.Games.Include(s =>s.Genres).FirstOrDefault(s => s.Id == gameid);
			List<Genre> Topgenres = new List<Genre>();
			foreach (var genre in game.Genres)
			{
				var sorted = genre.Games.OrderByDescending(e => e.MetacriticRating).ToList();
				var top = sorted.Take(10);
				if (top.Contains(game))
				{
					Topgenres.Add(genre);
				}
			}
			return Topgenres;
		}
	}
}
