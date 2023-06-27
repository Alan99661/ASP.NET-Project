using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Text.Json;
using VideoGameApplication.Api;
using VideoGameApplication.Api.Contracts;
using VideoGameApplication.Api.Models;
using VideoGameApplication.Database;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplicationMVC.Controllers
{
    public class APIController : Controller
    {
        private readonly IApiFetcher _handler;

        public APIController(IApiFetcher handler)
        {
            _handler = handler;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FetchGames()
        {
            string apikey = "05075852ec4844f7b273505b481247ff";
            var APIGameIdResult = await _handler.GetGameIds(apikey, 50);
            var games = await _handler.GetAPIGames(apikey, APIGameIdResult);

            return Json(games);
        }

    }
}