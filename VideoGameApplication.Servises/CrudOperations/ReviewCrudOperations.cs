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
using VideoGameApplication.Servises.ViewModels.ReviewViewModels;
using VideoGameApplication.Servises.ViewModels.ScreenshotViewModels;

namespace VideoGameApplication.Servises.CrudOperations
{
    internal class ReviewCrudOperations : IReviewCrudOperations

    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public ReviewCrudOperations(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<ReviewViewModel> GetAll()
        {
            try
            {

                var res = context.Reviews
                    .Select(s => s)
                    .Include(s => s.Game)
                    .Include(s => s.User)
                    .ToList();

                return mapper.Map<List<ReviewViewModel>>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public ReviewViewModel GetById(string id)
        {
            try
            {


                var res = context.Reviews
                    .Include(s => s.Game)
                    .Include(s => s.User)
                    .FirstOrDefault(s => s.Id == id);

                return mapper.Map<ReviewViewModel>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public ReviewViewModel CreateReview(ReviewAddModel addModel)
        {
            try
            {

                var review = mapper.Map<Review>(addModel);
                var game = context.Games.FirstOrDefault(s => s.Id == addModel.GameId);
                var user = context.Users.FirstOrDefault(s => s.Id == addModel.UserId);
                review.Game = game;
                review.User = user;
                context.Reviews.Add(review);
                context.SaveChanges();

                return mapper.Map<ReviewViewModel>(review);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public ReviewViewModel UpdateReview(ReviewUpdateModel updateModel)
        {
            try
            {
                var review = context.Reviews.FirstOrDefault(s => s.Id == updateModel.Id);
                var game = context.Games.FirstOrDefault(s => s.Id == updateModel.GameId);
                var user = context.Users.FirstOrDefault(s => s.Id == updateModel.UserId);
                review.User = user;
                review.Game = game;
                context.Update(review);
                context.SaveChanges();

                return mapper.Map<ReviewViewModel>(review);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed");
            }
        }
        public string DeleteScreenshot(ReviewDeleteModel deleteModel)
        {
            try
            {
                var review = context.Reviews.FirstOrDefault(s => s.Id == deleteModel.Id);
                context.Remove(review);
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
