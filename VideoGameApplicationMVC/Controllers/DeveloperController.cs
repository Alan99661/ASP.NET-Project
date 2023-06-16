using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.Other;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.OtherOperations;
using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;

namespace VideoGameApplicationMVC.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperCrudOperations _operations;
        private readonly IGetUpdateModels _getDevUpdateModel;
        private readonly IGetSelectModels _getSelectModel;

        public DeveloperController(IDeveloperCrudOperations developerCrudOperations, IGetUpdateModels getDevUpdateModel,IGetSelectModels getSelectModels)
        {
            _operations = developerCrudOperations;
            _getDevUpdateModel = getDevUpdateModel;
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
		public IActionResult CreateDeveloper() 
        {
            return View();
        }
		[Authorize(Roles = "Admin")]
		public IActionResult CreateDeveloperPost(DeveloperAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.CreateDeveloper(model);
            return Redirect("/Developer/GetById/" + res.Id);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateDeveloper(string id)
        {
            var model = _getDevUpdateModel.GetDevUpdateModel(id);
            return View(model);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult UpdateDeveloperPost(DeveloperUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.UpdeteDeveloper(model);
            return Redirect("/Developer/GetById/" + res.Id);
        }
		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDeveloperPost(string id)
        {
            var res = _operations.DeleteDeveloper(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetDeveloperSelectModel()
        {
            var models = _getSelectModel.GetDeveloperSelectModels();
            return Json(models);
        }
    }
}
