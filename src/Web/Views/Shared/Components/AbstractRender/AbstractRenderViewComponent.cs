namespace MoviesApp.Web.Views.Shared.Components.AbstractRender
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using ViewModels.Render;
    using ViewModels;

    public class AbstractRenderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(RenderViewModel model)
        {
            int currentPage = model.CurrentPage;
            int pageSize = model.PageSize;
            var entities = model.Entities;

            var movies = entities.Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            int totalItems = entities.Count();

            var viewModel = new AbstractRenderViewModel(movies,
                model, totalItems);
            return this.View("Default", viewModel);
        }
    }
}
