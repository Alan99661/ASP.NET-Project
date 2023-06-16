using Microsoft.AspNetCore.Mvc;
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

        public GameController(IGameCrudOperations operations, IGetUpdateModels getUpdateModels, IGetSelectModels getSelectModel, IGetGameStats gameStats)
        {
            this._operations = operations;
            _getUpdateModels = getUpdateModels;
            _getSelectModel = getSelectModel;
            _gameStats = gameStats;
        }

        public IActionResult Index()
        {
            var res = _operations.GetAll();
            return View(res);
        }
        public IActionResult GetById(string id)
        {
            var res = _operations.GetById(id);
            return View(res);
        }
        public IActionResult CreateGame()
        {
            return View();
        }
        public IActionResult CreateGamePost(GameAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.CreateGame(model);
            return Redirect("/Game/GetById/" + res.Id);
        }
        public IActionResult UpdateGame(string id)
        {
            var model = _getUpdateModels.GetGameUpdateModel(id);
            return View(model);
        }
        public IActionResult UpdateGamePost(GameUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.UpdateGame(model);
            return Redirect("/Game/GetById/" + res.Id);
        }

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
    }
}
