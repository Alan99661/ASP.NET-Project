using VideoGameApplication.Servises.ViewModels.ReviewViewModels;

namespace VideoGameApplication.Servises.Contracts
{
    internal interface IReviewCrudOperations
    {
        ReviewViewModel CreateReview(ReviewAddModel addModel);
        string DeleteScreenshot(ReviewDeleteModel deleteModel);
        List<ReviewViewModel> GetAll();
        ReviewViewModel GetById(string id);
        ReviewViewModel UpdateReview(ReviewUpdateModel updateModel);
    }
}