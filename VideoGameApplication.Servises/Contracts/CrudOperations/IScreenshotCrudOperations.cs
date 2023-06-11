using VideoGameApplication.Servises.ViewModels.ScreenshotViewModels;

namespace VideoGameApplication.Servises.Contracts.CrudOperations
{
    public interface IScreenshotCrudOperations
    {
        ScreenshotViewModel CreateScreenshot(ScreenshotAddModel addModel);
        string DeleteScreenshot(ScreenshotDeleteModel deleteModel);
        List<ScreenshotViewModel> GetAll();
        ScreenshotViewModel GetById(string id);
        ScreenshotViewModel UpdateScreenshot(ScreenshotUpdateModel updateModel);
    }
}