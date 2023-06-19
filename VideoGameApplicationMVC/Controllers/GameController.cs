using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.Other;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.ViewModels.GameViewModels;
using VideoGameApplication.Servises.ViewModels.GameViewModels;

namespace VideoGameApplicationMVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameCrudOperations _operations;
        private readonly IGetUpdateModels _getUpdateModels;
        private readonly IGetSelectModels _getSelectModel;
        private readonly IGetGameStats _gameStats;
        private readonly ISearchEntities _searchEntities;

        public GameController(IGameCrudOperations operations, IGetUpdateModels getUpdateModels, IGetSelectModels getSelectModel, IGetGameStats gameStats, ISearchEntities searchEntities)
        {
            this._operations = operations;
            _getUpdateModels = getUpdateModels;
            _getSelectModel = getSelectModel;
            _gameStats = gameStats;
            _searchEntities = searchEntities;
        }

        public IActionResult Index()
        {
            var res = _operations.GetAll();
            return View(res);
        }
        public IActionResult GetById(string id)
        {
            ViewBag.TopGenres = _gameStats.GetTopGenres(id);
			var res = _operations.GetById(id);
            return View(res);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult CreateGame()
        {
            return View();
        }
		[Authorize(Roles = "Admin")]
		public IActionResult CreateGamePost(GameAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.CreateGame(model);
            return Redirect("/Game/GetById/" + res.Id);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateGame(string id)
        {
            var model = _getUpdateModels.GetGameUpdateModel(id);
            return View(model);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateGamePost(GameUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.UpdateGame(model);
            return Redirect("/Game/GetById/" + res.Id);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult DeleteGamePost(string id)
        {
            var res = _operations.DeleteGame(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetGameSelectModel()
        {
            var models = _getSelectModel.GetGamesSelectModels();
            return Json(models);
        }
        public IActionResult CheckTopGenres(string id)
        {
            var res = _gameStats.GetTopGenres(id);
            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> SearchGames(GameSearchModel gameSearchModel)
        {
            List<GameViewModel> res = await _searchEntities.SearchGames(gameSearchModel);
            return View();
        }
    }
}
