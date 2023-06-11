using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;

namespace VideoGameApplication.Servises.Contracts.CrudOperations
{
    public interface IDeveloperCrudOperations
    {
        DeveloperViewModel CreateDeveloper(DeveloperAddModel addModel);
        string DeleteDeveloper(string id);
        List<DeveloperViewModel> GetAll();
        DeveloperViewModel GetById(string id);
        DeveloperViewModel UpdeteDeveloper(DeveloperUpdateModel updateModel);
    }
}