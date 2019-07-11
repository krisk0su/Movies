namespace MoviesApp.Web.Views.Shared.Components.MoviesRender
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using System.Linq;
    using ViewModels.Movies;
    using ViewModels.Render;

    public class MoviesRenderViewComponent:ViewComponent
    {
        private readonly IMoviesService _moviesService;

        public MoviesRenderViewComponent(IMoviesService service)
        {
            this._moviesService = service;
        }

        public IViewComponentResult Invoke(RenderViewModel model)
        {
            int currentPage = model.CurrentPage;
            int pageSize = model.PageSize;

            var entities = this._moviesService.AllMovies();

            var movies = entities.Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            int totalItems = entities.Count();

            var viewModel = new DisplayAllMoviesViewModel(movies, 
                model, totalItems);
            return this.View("Default", viewModel);
        }

    }
}
