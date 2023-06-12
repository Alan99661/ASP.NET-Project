﻿using Microsoft.AspNetCore.Mvc;
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
		private readonly IGetSelectModels _getSelectModel;

		public ReviewController(IReviewCrudOperations operations, IGetUpdateModels getUpdateModel, IGetSelectModels getSelectModels)
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
		public IActionResult CreateReview()
		{
			return View();
		}
		public IActionResult CreateReviewPost(ReviewAddModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
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
				return View(model);
			}
			var res = _operations.UpdateReview(model);
			return Redirect("/Review/GetById/" + res.Id);
		}

		public IActionResult DeleteReviewPost(string id)
		{
			var res = _operations.DeleteReview(id);
			return RedirectToAction("Index");
		}
		//public IActionResult GetReviewSelectModel()
		//{
		//	var models = _getSelectModel.GetReviewSelectModels();
		//	return Json(models);
		//}
	}
}
