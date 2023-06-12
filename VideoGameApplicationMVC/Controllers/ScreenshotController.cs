using Microsoft.AspNetCore.Mvc;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.Other;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.ViewModels.ScreenshotViewModels;

namespace VideoGameApplicationMVC.Controllers
{
	public class ScreenshotController : Controller
	{
		private readonly IScreenshotCrudOperations _operations;
		private readonly IGetUpdateModels _getUpdateModel;
		private readonly IGetSelectModels _getSelectModel;

		public ScreenshotController(IScreenshotCrudOperations operations, IGetUpdateModels getUpdateModel, IGetSelectModels getSelectModels)
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
		public IActionResult CreateScreenshot()
		{
			return View();
		}
		public IActionResult CreateScreenshotPost(ScreenshotAddModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var res = _operations.CreateScreenshot(model);
			return Redirect("/Screenshot/GetById/" + res.Id);
		}
		public IActionResult UpdateScreenshot(string id)
		{
			var model = _getUpdateModel.GetScreenshotUpdateModel(id);
			return View(model);
		}
		public IActionResult UpdateScreenshotPost(ScreenshotUpdateModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var res = _operations.UpdateScreenshot(model);
			return Redirect("/Screenshot/GetById/" + res.Id);
		}

		public IActionResult DeleteScreenshotPost(string id)
		{
			var res = _operations.DeleteScreenshot(id);
			return RedirectToAction("Index");
		}
		//public IActionResult GetScreenshotSelectModel()
		//{
		//	var models = _getSelectModel.GetScreenshotSelectModels();
		//	return Json(models);
		//}
	}
}
