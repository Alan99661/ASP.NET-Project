using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VideoGameApplication.Servises.Contracts;
using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;

namespace VideoGameApplicationMVC.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IDeveloperCrudOperations _operations;

        public DeveloperController(IDeveloperCrudOperations developerCrudOperations)
        {
            _operations = developerCrudOperations;
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
        public IActionResult UpdateDeveloper()
        {
            return View();
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
