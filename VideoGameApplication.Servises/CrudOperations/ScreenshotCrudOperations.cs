using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.ViewModels.ScreenshotViewModels;

namespace VideoGameApplication.Servises.CrudOperations
{
    public class ScreenshotCrudOperations : IScreenshotCrudOperations
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public ScreenshotCrudOperations(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<ScreenshotViewModel> GetAll()
        {
            try
            {

                var res = context.Screenshots
                    .Select(s => s)
                    .Include(s => s.Game)
                    .ToList();

                return mapper.Map<List<ScreenshotViewModel>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public ScreenshotViewModel GetById(string id)
        {
            try
            {


                var res = context.Screenshots
                    .Include(s => s.Game)
                    .FirstOrDefault(s => s.Id == id);

                return mapper.Map<ScreenshotViewModel>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public ScreenshotViewModel CreateScreenshot(ScreenshotAddModel addModel)
        {
            try
            {

                var screenshot = mapper.Map<Screenshot>(addModel);
                var game = context.Games.FirstOrDefault(s => s.Id == addModel.GameId);
                screenshot.Game = game;
                context.Screenshots.Add(screenshot);
                context.SaveChanges();

                return mapper.Map<ScreenshotViewModel>(screenshot);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public ScreenshotViewModel UpdateScreenshot(ScreenshotUpdateModel updateModel)
        {
            try
            {
                var screenshot = context.Screenshots.FirstOrDefault(s => s.Id == updateModel.Id);
                var game = context.Games.FirstOrDefault(s => s.Id == updateModel.GameId);
                screenshot.Url = updateModel.Url;
                screenshot.Game = game;
                context.Update(screenshot);
                context.SaveChanges();

                return mapper.Map<ScreenshotViewModel>(screenshot);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public string DeleteScreenshot(string id)
        {
            try
            {
                var screenshot = context.Screenshots.FirstOrDefault(s => s.Id == id);
                context.Remove(screenshot);
                context.SaveChanges();

                return "Sucsess";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
    }
}
