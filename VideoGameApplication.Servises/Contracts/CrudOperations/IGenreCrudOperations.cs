using VideoGameApplication.Servises.ViewModels.GenreViewModels;

namespace VideoGameApplication.Servises.Contracts.CrudOperations
{
    public interface IGenreCrudOperations
    {
        GenreViewModel CreateGenre(GenreAddModel addModel);
        string DeleteGenre(GenreDeleteModel deleteModel);
        List<GenreViewModel> GetAll();
        GenreViewModel GetById(string id);
        GenreViewModel UpdeteGenre(GenreUpdateModel updateModel);
    }
}