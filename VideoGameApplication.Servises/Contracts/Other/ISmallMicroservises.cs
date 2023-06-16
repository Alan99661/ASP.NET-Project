using VideoGameApplication.Servises.ViewModels.ReviewViewModels;

namespace VideoGameApplication.Servises.Contracts.Other
{
    public interface ISmallMicroservises
    {
        ReviewViewModel CertifyReview(string id);
    }
}