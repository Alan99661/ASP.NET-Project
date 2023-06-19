
using Azure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json;
using VideoGameApplication.Api.Contracts;
using VideoGameApplication.Api.Models;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Api.Servises
{
    public class APIHandler : IAPIHandler
    {
        private readonly HttpClient _httpClient;
        private readonly VideoGameDBContext _dbContext;
        private readonly IAPIListChecker _listChecker;

        public APIHandler(HttpClient httpClient, VideoGameDBContext dbContext, IAPIListChecker listChecker)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
            _listChecker = listChecker;
        }

        public async Task<APIGameIdResult> GetGameIds(string key, int count)
        {
            var endpoint = $"https://api.rawg.io/api/games?ordering=relevance&platforms=13&page_size={count}&key={key}";
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
                        Developers = _listChecker.GetDeveloperList(apiGame.Developers),
                        Genres = _listChecker.GetGenreList(apiGame.Genres),
                        Platforms = _listChecker.GetPlatformList(apiGame.parent_platforms),
                        Screenshots = _listChecker.GetScreenshotList(IdNamePair.Short_screenshots)

                    };
                    _dbContext.Games.Add(gameEnt);
                    _dbContext.SaveChanges();
                }
            }
            return "Gucci";
        }

    }
}