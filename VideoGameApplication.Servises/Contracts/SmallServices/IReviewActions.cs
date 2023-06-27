using VideoGameApplication.Servises.ViewModels.ReviewViewModels;

namespace VideoGameApplication.Servises.Contracts.SmallServices
{
    public interface IReviewActions
    {
        ReviewViewModel CertifyReview(string id);
    }
}