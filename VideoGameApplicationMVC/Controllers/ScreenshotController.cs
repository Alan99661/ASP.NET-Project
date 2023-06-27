using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.SmallServices;
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
		[Authorize(Roles ="Admin")]
		public IActionResult Index()
		{
			var res = _operations.GetAll();
			return View(res);
		}
		[Authorize(Roles = "Admin")]
		public IActionResult CreateScreenshot()
		{
			return View();
		}
		[Authorize(Roles = "Admin")]
		public IActionResult CreateScreenshotPost(ScreenshotAddModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var res = _operations.CreateScreenshot(model);
			return Redirect("/Screenshot/GetById/" + res.Id);
		}
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateScreenshot(string id)
		{
			var model = _getUpdateModel.GetScreenshotUpdateModel(id);
			return View(model);
		}
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateScreenshotPost(ScreenshotUpdateModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var res = _operations.UpdateScreenshot(model);
			return Redirect("/Screenshot/GetById/" + res.Id);
		}
		[Authorize(Roles = "Admin")]
		public IActionResult DeleteScreenshotPost(string id)
		{
			var res = _operations.DeleteScreenshot(id);
			return RedirectToAction("Index");
		}
	}
}
