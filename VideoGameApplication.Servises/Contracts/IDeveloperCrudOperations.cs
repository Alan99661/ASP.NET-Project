﻿using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;

namespace VideoGameApplication.Servises.Contracts
{
    public interface IDeveloperCrudOperations
    {
        DeveloperViewModel CreateDeveloper(DeveloperAddModel addModel);
        string DeleteDeveloper(DeveloperDeleteModel deleteModel);
        List<DeveloperViewModel> GetAll();
        DeveloperViewModel GetById(string id);
        DeveloperViewModel UpdeteDeveloper(DeveloperUpdateModel updateModel);
    }
}