
using Azure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json;
using VideoGameApplication.Api.Contracts;
using VideoGameApplication.Api.Models;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Api
{
    public class APIHandler : IAPIHandler
    {
        private readonly HttpClient _httpClient;
        private readonly VideoGameDBContext _dbContext;

        public APIHandler(HttpClient httpClient, VideoGameDBContext dbContext)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
        }

        public async Task<APIGameIdResult> GetGameIds(string key, int count)
        {
            var endpoint = $"https://api.rawg.io/api/games?ordering=relevance&page_size={count}&key={key}";
            var httpResponseMessage = await _httpClient.GetAsync(endpoint);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var json = await httpResponseMessage.Content.ReadAsStringAsync();
                var IdNamePairs = JsonSerializer.Deserialize<APIGameIdResult>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return IdNamePairs;
            }
            return null;
        }

        public async Task<string> GetAPIGames(string key, APIGameIdResult gameIdResult)
        {
            foreach (var IdNamePair in gameIdResult.Results)
            {
                if (_dbContext.Games.FirstOrDefault(x => x.Name == IdNamePair.Name.ToString()) != null) continue;
                var endpoint = $"https://api.rawg.io/api/games/{IdNamePair.Id}?&key={key}";
                var httpResponseMessage = await _httpClient.GetAsync(endpoint);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var gameJson = await httpResponseMessage.Content.ReadAsStringAsync();
                    var apiGame = JsonSerializer.Deserialize<APIGame>(gameJson, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var gameEnt = new Game()
                    {
                        Name = apiGame.Name,
                        ReleaseDate = Convert.ToDateTime(apiGame.Released),
                        Description = apiGame.Description_raw,
                        BackgroundImageUrl = apiGame.background_image,
                        MetacriticRating = apiGame.Metacritic,
                        GameWebsite = apiGame.Website,
                        Developers = apiGame.Developers.Select(s => new Developer()
                        {
                            
                            Name = s.Name
                        }).ToList(),
                        Genres = apiGame.Genres.Select(s => new Genre()
                        {
                            Name = s.Name,
                        }).ToList(),
                        Platforms = apiGame.parent_platforms.Select(s => new Platform()
                        {
                            Name = s.Platform.Name,
                        }).ToList(),
                        Screenshots = IdNamePair.Short_screenshots.Select(s => new Screenshot()
                        {
                            Url = s.Image,
                        }).ToList()

                    };

                    _dbContext.Games.Add(gameEnt);
                    _dbContext.SaveChanges();
                }
            }
            return "Gucci";
        }

    }
}