using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;

namespace VideoGameApplicationMVC.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperCrudOperations _operations;
        private readonly IGetUpdateModels _getDevUpdateModel;

        public DeveloperController(IDeveloperCrudOperations developerCrudOperations, IGetUpdateModels getDevUpdateModel)
        {
            _operations = developerCrudOperations;
            _getDevUpdateModel = getDevUpdateModel;
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
        public IActionResult CreateDeveloper() 
        {
            return View();
        }
        public IActionResult CreateDeveloperPost(DeveloperAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.CreateDeveloper(model);
            return Redirect("/Developer/GetById/" + res.Id);
        }
        public IActionResult UpdateDeveloper(string id)
        {
            var model = _getDevUpdateModel.GetDevUpdateModel(id);
            return View(model);
        }
        public IActionResult UpdateDeveloperPost(DeveloperUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = _operations.UpdeteDeveloper(model);
            return Redirect("/Developer/GetById/" + res.Id);
        }

        public IActionResult DeleteDeveloperPost(string id)
        {
            var res = _operations.DeleteDeveloper(id);
            return RedirectToAction("Index");
        }
    }
}
