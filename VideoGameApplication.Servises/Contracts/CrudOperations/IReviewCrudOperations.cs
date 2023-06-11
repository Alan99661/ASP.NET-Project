using VideoGameApplication.Servises.ViewModels.ReviewViewModels;

namespace VideoGameApplication.Servises.Contracts.CrudOperations
{
    public interface IReviewCrudOperations
    {
        ReviewViewModel CreateReview(ReviewAddModel addModel);
        string DeleteScreenshot(string id);
        List<ReviewViewModel> GetAll();
        ReviewViewModel GetById(string id);
        ReviewViewModel UpdateReview(ReviewUpdateModel updateModel);
    }
}