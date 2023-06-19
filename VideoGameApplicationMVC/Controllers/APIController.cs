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
        private readonly IAPIHandler _handler;

        public APIController(IAPIHandler handler)
        {
            _handler = handler;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Games()
        {
            var APIGameIdResult =await _handler.GetGameIds("05075852ec4844f7b273505b481247ff", 10);
            var games = await _handler.GetAPIGames("05075852ec4844f7b273505b481247ff", APIGameIdResult);

            return Json(games);
        }

    }
}