using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.ViewModels.GameViewModels;

namespace VideoGameApplication.Servises.CrudOperations
{
    public class GameCrudOperations : IGameCrudOperations
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public GameCrudOperations(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<GameViewModel> GetAll()
        {
            try
            {

                var res = context.Games
                     .Select(s => s)
                     .Include(s => s.Developers)
                     .Include(s => s.Genres)
                     .Include(s => s.Platforms)
                     .Include(s => s.Screenshots)
                     .Include(s => s.Reviews)
                     .ToList();

                return mapper.Map<List<GameViewModel>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public GameViewModel GetById(string id)
        {
            try
            {

                var res = context.Games
                     .Include(s => s.Developers)
                     .Include(s => s.Genres)
                     .Include(s => s.Platforms)
                     .Include(s => s.Screenshots)
                     .Include(s => s.Reviews)
                     .FirstOrDefault(s => s.Id == id);

                return mapper.Map<GameViewModel>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }

        public GameViewModel CreateGame(GameAddModel addModel)
        {
            try
            {
                var game = mapper.Map<Game>(addModel);
                var devs = context.Developers
                    .Where(s => addModel.DeveloperIds
                    .Contains(s.Id))
                    .ToList();
                var platforms = context.Platforms
                    .Where(s => addModel.PlatformIds
                    .Contains(s.Id))
                    .ToList();
                var reviews = context.Reviews
                    .Where(s => addModel.ReviewIds
                    .Contains(s.Id))
                    .ToList();
                var genres = context.Genres
                    .Where(s => addModel.GenreIds
                    .Contains(s.Id))
                    .ToList();
                var screenshots = context.Screenshots
                    .Where(s => addModel.ScreenshotIds
                    .Contains(s.Id))
                    .ToList();

                game.Screenshots = screenshots;
                game.Genres = genres;
                game.Reviews = reviews;
                game.Developers = devs;
                game.Platforms = platforms;
                context.Games.Add(game);
                context.SaveChanges();

                return mapper.Map<GameViewModel>(game);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }

        public GameViewModel UpdateGame(GameUpdateModel updateModel)
        {
            try
            {

                var game = context.Games
                    .FirstOrDefault(s => s.Id == updateModel.Id);
                var devs = context.Developers
                    .Where(s => updateModel.DeveloperIds
                    .Contains(s.Id))
                    .ToList();
                var platforms = context.Platforms
                    .Where(s => updateModel.PlatformIds
                    .Contains(s.Id))
                    .ToList();
                var reviews = context.Reviews
                    .Where(s => updateModel.ReviewIds
                    .Contains(s.Id))
                    .ToList();
                var genres = context.Genres
                    .Where(s => updateModel.GenreIds
                    .Contains(s.Id))
                    .ToList();
                var screenshots = context.Screenshots
                    .Where(s => updateModel.ScreenshotIds
                    .Contains(s.Id))
                    .ToList();

                game.Screenshots = screenshots;
                game.Genres = genres;
                game.Reviews = reviews;
                game.Developers = devs;
                game.Platforms = platforms;
                game.Name = updateModel.Name;
                game.MetacriticRating = updateModel.MetacriticRating;
                game.BackgroundImageUrl = updateModel.BackgroundImageUrl;
                game.Description = updateModel.Description;
                game.GameWebsite = updateModel.GameWebsite;
                game.ReleaseDate = updateModel.ReleaseDate;

                context.Games.Update(game);
                context.SaveChanges();

                return mapper.Map<GameViewModel>(game);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }

        public string DeleteGame(string id)
        {
            try
            {
                var res = context.Games.FirstOrDefault(s => s.Id == id);
                context.Remove(res);
                context.SaveChanges();

                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
    }
}
