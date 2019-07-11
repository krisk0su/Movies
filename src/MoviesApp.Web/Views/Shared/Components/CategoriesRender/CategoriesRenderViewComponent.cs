namespace MoviesApp.Web.Views.Shared.Components.CategoriesRender
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using MoviesApp.Data.Models.Categories;
    using ViewModels.Categories;

    public class CategoriesRenderViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public IEnumerable<Category> Categories { get; set; }

        public CategoriesRenderViewComponent(ICategoryService service)
        {
            this._categoryService = service;
            this.Categories = service.AllCategories();
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = this.GetCategories();

            return this.View("Default", viewModel);
        }

        private DisplayCategoriesViewModel GetCategories()
        {
            var viewModel = new DisplayCategoriesViewModel();
            if (this.Categories.Count() == 0)
            {
                return viewModel;
            }

            var count = this.Categories.Count();
            var numTake = count / 2;
            if (count % 2 != 0) numTake = (count / 2) + 1;
           
            viewModel.FirstColumn = this.Categories.Take(numTake);

            viewModel.SecondColumn = this.Categories.Skip(numTake).Take(count/2);

            return viewModel;
        }
    }
}
