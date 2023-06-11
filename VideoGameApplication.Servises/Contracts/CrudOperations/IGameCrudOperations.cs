using VideoGameApplication.Servises.ViewModels.GameViewModels;

namespace VideoGameApplication.Servises.Contracts.CrudOperations
{
    internal interface IGameCrudOperations
    {
        GameViewModel CreateGame(GameAddModel addModel);
        string DeleteGame(string id);
        List<GameViewModel> GetAll();
        GameViewModel GetById(string id);
        GameViewModel UpdateGame(GameUpdateModel updateModel);
    }
}