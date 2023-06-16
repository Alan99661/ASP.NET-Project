using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.Other;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.ViewModels.PlatformViewModels;
using VideoGameApplication.Servises.ViewModels.PlatformViewModels;

namespace VideoGameApplicationMVC.Controllers
{
    public class PlatformController : Controller
    {
        private readonly IPlatformCrudOperations _operations;
        private readonly IGetUpdateModels _getUpdateModel;
        private readonly IGetSelectModels _getSelectModel;

        public PlatformController(IPlatformCrudOperations operations, IGetUpdateModels getUpdateModel, IGetSelectModels getSelectModels)
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
		[Authorize(Roles = "Admin")]
		public IActionResult CreatePlatform()
        {
            return View();
        }
		[Authorize(Roles = "Admin")]
		public IActionResult CreatePlatformPost(PlatformAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.CreatePlatform(model);
            return Redirect("/Platform/GetById/" + res.Id);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult UpdatePlatform(string id)
        {
            var model = _getUpdateModel.GetPlatformUpdateModel(id);
            return View(model);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult UpdatePlatformPost(PlatformUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.UpdetePlatform(model);
            return Redirect("/Platform/GetById/" + res.Id);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult DeletePlatformPost(string id)
        {
            var res = _operations.DeletePlatform(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetPlatformSelectModel()
        {
            var models = _getSelectModel.GetPlatformSelectModels();
            return Json(models);
        }
    }
}

