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
using VideoGameApplication.Servises.ViewModels.GenreViewModels;

namespace VideoGameApplication.Servises.CrudOperations
{
    public class GenreCrudOperations : IGenreCrudOperations
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public GenreCrudOperations(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<GenreViewModel> GetAll()
        {
            try
            {

                var res = context.Genres
                    .Select(s => s)
                    .Include(s => s.Games)
                    .ToList();

                return mapper.Map<List<GenreViewModel>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public GenreViewModel GetById(string id)
        {
            try
            {


                var res = context.Genres
                    .Include(s => s.Games)
                    .FirstOrDefault(s => s.Id == id);

                return mapper.Map<GenreViewModel>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public GenreViewModel CreateGenre(GenreAddModel addModel)
        {
            try
            {

                var genre = mapper.Map<Genre>(addModel);
                var games = context.Games
                    .Where(e => addModel.GameIds.Contains(e.Id))
                    .ToList();
                genre.Games = games;
                context.Genres.Add(genre);
                context.SaveChanges();

                return mapper.Map<GenreViewModel>(genre);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public GenreViewModel UpdeteGenre(GenreUpdateModel updateModel)
        {
            try
            {
                var genre = context.Genres.FirstOrDefault(s => s.Id == updateModel.Id);
                var games = context.Games
                   .Where(e => updateModel.GameIds.Contains(e.Id))
                   .ToList();
                genre.Games = games;
                genre.Name = updateModel.Name;
                context.Update(genre);
                context.SaveChanges();

                return mapper.Map<GenreViewModel>(genre);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public string DeleteGenre(string id)
        {
            try
            {
                var genre = context.Genres.FirstOrDefault(s => s.Id == id);
                context.Remove(genre);
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

