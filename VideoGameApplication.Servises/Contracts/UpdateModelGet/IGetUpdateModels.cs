using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;

namespace VideoGameApplication.Servises.Contracts.UpdateModelGet
{
    public interface IGetUpdateModels
    {
        DeveloperUpdateModel GetDevUpdateModel(string id);
    }
}