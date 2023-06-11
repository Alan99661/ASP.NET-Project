using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.ViewModels.PlatformViewModels;

namespace VideoGameApplication.Servises.CrudOperations
{
    public class PlatformCrudOperations : IPlatformCrudOperations
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public PlatformCrudOperations(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<PlatformViewModel> GetAll()
        {
            try
            {

                var res = context.Platforms
                    .Select(s => s)
                    .Include(s => s.Games)
                    .ToList();

                return mapper.Map<List<PlatformViewModel>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public PlatformViewModel GetById(string id)
        {
            try
            {


                var res = context.Platforms
                    .Include(s => s.Games)
                    .FirstOrDefault(s => s.Id == id);

                return mapper.Map<PlatformViewModel>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public PlatformViewModel CreatePlatform(PlatformAddModel addModel)
        {
            try
            {

                var Platform = mapper.Map<Platform>(addModel);
                var games = context.Games
                    .Where(e => addModel.GameIds.Contains(e.Id))
                    .ToList();
                Platform.Games = games;
                context.Platforms.Add(Platform);
                context.SaveChanges();

                return mapper.Map<PlatformViewModel>(Platform);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public PlatformViewModel UpdetePlatform(PlatformUpdateModel updateModel)
        {
            try
            {
                var Platform = context.Platforms.FirstOrDefault(s => s.Id == updateModel.Id);
                var games = context.Games
                   .Where(e => updateModel.GameIds.Contains(e.Id))
                   .ToList();
                Platform.Games = games;
                Platform.Name = updateModel.Name;
                context.Update(Platform);
                context.SaveChanges();

                return mapper.Map<PlatformViewModel>(Platform);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public string DeletePlatform(string id)
        {
            try
            {
                var Platform = context.Platforms.FirstOrDefault(s => s.Id == id);
                context.Remove(Platform);
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
