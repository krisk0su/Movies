using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesApp.Services.DataServices.Contracts
{
    using ViewModels.Categories;
    using System.Collections.Generic;using Data.Models.Categories;

    public interface ICategoryService
    {
        IList<Category> AllCategories();

        IList<SelectListItem> SelectList();

        Task<int> Create(CreateCategoryViewModel model);

        Task<int> CreateCategory(string name);

        DetailsCategoryViewModel Details(string id);

    }
}
