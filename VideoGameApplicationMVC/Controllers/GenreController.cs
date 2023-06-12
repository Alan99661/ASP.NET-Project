using Microsoft.AspNetCore.Mvc;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.Other;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.ViewModels.GenreViewModels;

namespace VideoGameApplicationMVC.Controllers
{
	public class GenreController : Controller
	{
		private readonly IGenreCrudOperations _operations;
		private readonly IGetUpdateModels _getUpdateModel;
		private readonly IGetSelectModels _getSelectModel;

		public GenreController(IGenreCrudOperations operations, IGetUpdateModels getUpdateModel, IGetSelectModels getSelectModels)
		{
			_operations = operations;
			_getUpdateModel = getUpdateModel;
			_getSelectModel = getSelectModels;
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
		public IActionResult CreateGenre()
		{
			return View();
		}
		public IActionResult CreateGenrePost(GenreAddModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var res = _operations.CreateGenre(model);
			return Redirect("/Genre/GetById/" + res.Id);
		}
		public IActionResult UpdateGenre(string id)
		{
			var model = _getUpdateModel.GetGenreUpdateModel(id);
			return View(model);
		}
		public IActionResult UpdateGenrePost(GenreUpdateModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var res = _operations.UpdeteGenre(model);
			return Redirect("/Genre/GetById/" + res.Id);
		}

		public IActionResult DeleteGenrePost(string id)
		{
			var res = _operations.DeleteGenre(id);
			return RedirectToAction("Index");
		}
		public IActionResult GetGenreSelectModel()
		{
			var models = _getSelectModel.GetGenreSelectModels();
			return Json(models);
		}
	}
}
