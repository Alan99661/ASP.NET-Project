using VideoGameApplication.Servises.ViewModels.ReviewViewModels;

namespace VideoGameApplication.Servises.Contracts.Other
{
    public interface IReviewActions
    {
        ReviewViewModel CertifyReview(string id);
    }
}