using Microsoft.AspNetCore.Mvc;
using VideoGameApplication.Servises.Contracts.CrudOperations;
using VideoGameApplication.Servises.Contracts.Other;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.ViewModels.ReviewViewModels;

namespace VideoGameApplicationMVC.Controllers
{
	public class ReviewController : Controller
	{
		private readonly IReviewCrudOperations _operations;
		private readonly IGetUpdateModels _getUpdateModel;
		private readonly ISmallMicroservises _smallMicro;

		public ReviewController(IReviewCrudOperations operations, IGetUpdateModels getUpdateModel, ISmallMicroservises SmallMicro)
		{
			_operations = operations;
			_getUpdateModel = getUpdateModel;
			_smallMicro = SmallMicro;
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
		public IActionResult CreateReview(string id)
		{
			ViewData["gameId"] = id;
			return View();
		}
		public IActionResult CreateReviewPost(ReviewAddModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model.GameId, model);
			}
			var res = _operations.CreateReview(model);
			return Redirect("/Review/GetById/" + res.Id);
		}
		public IActionResult UpdateReview(string id)
		{
			var model = _getUpdateModel.GetReviewUpdateModel(id);
			return View(model);
		}
		public IActionResult UpdateReviewPost(ReviewUpdateModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model.GameId,model);
			}
			var res = _operations.UpdateReview(model);
			return Redirect("/Review/GetById/" + res.Id);
		}

		public IActionResult DeleteReviewPost(string id)
		{
			var res = _operations.DeleteReview(id);
			return RedirectToAction("Index");
		}
		public IActionResult CertifyReview(string id)
		{
			var res = _smallMicro.CertifyReview(id);
			return RedirectToAction("Index");
		}
	}
}
