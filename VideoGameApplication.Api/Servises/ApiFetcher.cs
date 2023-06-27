
using Azure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json;
using VideoGameApplication.Api.Contracts;
using VideoGameApplication.Api.Models;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Api.Servises
{
    public class ApiFetcher : IApiFetcher
    {
        private readonly HttpClient _httpClient;
        private readonly VideoGameDBContext _dbContext;
        private readonly IApiListChecker _listChecker;

        public ApiFetcher(HttpClient httpClient, VideoGameDBContext dbContext, IApiListChecker listChecker)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
            _listChecker = listChecker;
        }

        public async Task<ApiGameIdResult> GetGameIds(string key, int count)
        {
            var endpoint = $"https://api.rawg.io/api/games?ordering=relevance&key={key}";
            var httpResponseMessage = await _httpClient.GetAsync(endpoint);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var json = await httpResponseMessage.Content.ReadAsStringAsync();
                var IdNamePairs = JsonSerializer.Deserialize<ApiGameIdResult>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return IdNamePairs;
            }
            return null;
        }

        public async Task<string> GetAPIGames(string key, ApiGameIdResult gameIdResult)
        {
            foreach (var IdNamePair in gameIdResult.Results)
            {
                if (_dbContext.Games.FirstOrDefault(x => x.Name == IdNamePair.Name.ToString()) != null) continue;
                var endpoint = $"https://api.rawg.io/api/games/{IdNamePair.Id}?&key={key}";
                var httpResponseMessage = await _httpClient.GetAsync(endpoint);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var gameJson = await httpResponseMessage.Content.ReadAsStringAsync();
                    var apiGame = JsonSerializer.Deserialize<ApiGame>(gameJson, new JsonSerializerOptions
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
                        Developers = _listChecker.CheckDeveloperList(apiGame.Developers),
                        Genres = _listChecker.CheckGenreList(apiGame.Genres),
                        Platforms = _listChecker.CheckPlatformList(apiGame.parent_platforms),
                        Screenshots = _listChecker.CheckScreenshotList(IdNamePair.Short_screenshots)

                    };
                    _dbContext.Games.Add(gameEnt);
                    _dbContext.SaveChanges();
                }
            }
            return "Gucci";
        }

    }
}