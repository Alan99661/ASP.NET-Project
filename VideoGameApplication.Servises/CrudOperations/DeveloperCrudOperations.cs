using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;
using VideoGameApplication.Servises.Contracts;
using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;
using VideoGameApplication.Servises.ViewModels.ScreenshotViewModels;

namespace VideoGameApplication.Servises.CrudOperations
{
    public class DeveloperCrudOperations : IDeveloperCrudOperations
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public DeveloperCrudOperations(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<DeveloperViewModel> GetAll()
        {
            try
            {

                var res = context.Developers
                    .Select(s => s)
                    .Include(s => s.Games)
                    .ToList();

                return mapper.Map<List<DeveloperViewModel>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public DeveloperViewModel GetById(string id)
        {
            try
            {


                var res = context.Developers
                    .Include(s => s.Games)
                    .FirstOrDefault(s => s.Id == id);

                return mapper.Map<DeveloperViewModel>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public DeveloperViewModel CreateDeveloper(DeveloperAddModel addModel)
        {
            try
            {

                var dev = mapper.Map<Developer>(addModel);
                var games = context.Games
                    .Where(e => addModel.GameIds.Contains(e.Id))
                    .ToList();
                dev.Games = games;
                context.Developers.Add(dev);
                context.SaveChanges();

                return mapper.Map<DeveloperViewModel>(dev);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public DeveloperViewModel UpdeteDeveloper(DeveloperUpdateModel updateModel)
        {
            try
            {
                var dev = context.Developers.FirstOrDefault(s => s.Id == updateModel.Id);
                var games = context.Games
                   .Where(e => updateModel.GameIds.Contains(e.Id))
                   .ToList();
                dev.Games = games;
                dev.Name = updateModel.Name;
                context.Update(dev);
                context.SaveChanges();

                return mapper.Map<DeveloperViewModel>(dev);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public string DeleteDeveloper(string id)
        {
            try
            {
                var dev = context.Developers.FirstOrDefault(s => s.Id == id);
                context.Remove(dev);
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

