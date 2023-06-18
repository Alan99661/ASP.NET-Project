using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Api.Contracts;
using VideoGameApplication.Api.Models;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Api.Servises
{
    public class APIListChecker : IAPIListChecker
    {
        private readonly VideoGameDBContext dbContext;

        public APIListChecker(VideoGameDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Developer> GetDeveloperList(List<APIModel> apidevs)
        {
            var developers = new List<Developer>();
            foreach (var dev in apidevs)
            {
                Developer? res = dbContext.Developers.FirstOrDefault(s => s.Name == dev.Name);
                if (res != null)
                {
                    developers.Add(res);
                }
                else
                {
                    developers.Add(new Developer
                    {
                        Name = dev.Name,
                    });
                }
            }
            return developers;
        }

        public List<Genre> GetGenreList(List<APIModel> apigenres)
        {
            var genres = new List<Genre>();
            foreach (var genre in apigenres)
            {
                Genre? res = dbContext.Genres.FirstOrDefault(s => s.Name == genre.Name);
                if (res != null)
                {
                    genres.Add(res);
                }
                else
                {
                    genres.Add(new Genre
                    {
                        Name = genre.Name,
                    });
                }
            }
            return genres;
        }

        public List<Screenshot> GetScreenshotList(List<APIScreenshot> apiscreenshots)
        {
            var screenshots = new List<Screenshot>();
            foreach (var scr in apiscreenshots)
            {
                Screenshot? res = dbContext.Screenshots.FirstOrDefault(s => s.Url == scr.Image);
                if (res != null)
                {
                    screenshots.Add(res);
                }
                else
                {
                    screenshots.Add(new Screenshot
                    {
                        Url = scr.Image,
                    });
                }

            }
            return screenshots;
        }

        public List<Platform> GetPlatformList(List<APIPlatforms> apiPlatforms)
        {
            var platforms = new List<Platform>();
            foreach (var platform in apiPlatforms)
            {
                Platform? res = dbContext.Platforms.FirstOrDefault(s => s.Name == platform.Platform.Name);
                if (res != null)
                {
                    platforms.Add(res);
                }
                else
                {
                    platforms.Add(new Platform { Name = platform.Platform.Name, });
                }
            }
            return platforms;
        }
    }
}
