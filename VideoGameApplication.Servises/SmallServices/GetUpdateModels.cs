using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;
using VideoGameApplication.Servises.ViewModels.GameViewModels;
using VideoGameApplication.Servises.ViewModels.GenreViewModels;
using VideoGameApplication.Servises.ViewModels.PlatformViewModels;
using VideoGameApplication.Servises.ViewModels.ReviewViewModels;
using VideoGameApplication.Servises.ViewModels.ScreenshotViewModels;

namespace VideoGameApplication.Servises.OtherOperations
{

    public class GetUpdateModels : IGetUpdateModels
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public GetUpdateModels(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public DeveloperUpdateModel GetDevUpdateModel(string id)
        {
            var res = context.Developers.FirstOrDefault(x => x.Id == id);
            return mapper.Map<DeveloperUpdateModel>(res);
        }
        public GameUpdateModel GetGameUpdateModel(string id)
        {
            var res = context.Games.FirstOrDefault(x => x.Id == id);
            return mapper.Map<GameUpdateModel>(res);
        }

        public GenreUpdateModel GetGenreUpdateModel(string id)
        {
            var res = context.Genres.FirstOrDefault(x => x.Id == id);
            return mapper.Map<GenreUpdateModel>(res);
        }

        public PlatformUpdateModel GetPlatformUpdateModel(string id)
        {
            var res = context.Platforms.FirstOrDefault(x => x.Id == id);
            return mapper.Map<PlatformUpdateModel>(res);
        }

        public ReviewUpdateModel GetReviewUpdateModel(string id)
        {
            var res = context.Reviews.FirstOrDefault(x => x.Id == id);
            return mapper.Map<ReviewUpdateModel>(res);
        }

        public ScreenshotUpdateModel GetScreenshotUpdateModel(string id)
        {
            var res = context.Screenshots.FirstOrDefault(x => x.Id == id);
            return mapper.Map<ScreenshotUpdateModel>(res);
        }
    }
}
