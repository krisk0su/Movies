using MoviesApp.ViewModels.Contracts;

namespace MoviesApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.Movies;
    using Microsoft.AspNetCore.Authorization;
    using ViewModels.Render;

    public class MoviesController:Controller
    {
        private readonly IMoviesService _moviesService;

        private readonly IMoviesCategoriesService _moviesCategoriesService;

        public MoviesController(IMoviesService moviesService, IMoviesCategoriesService mvService)
        {
            this._moviesService = moviesService;
            this._moviesCategoriesService = mvService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var vm = new CreateMovieViewModel() /*{SelectList = this._categoryService.SelectList()}*/;
            return View(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieViewModel model)
        {
            var movieId = await this._moviesService.Create(model);
            //try
            //{

            //    return this.RedirectToAction("AllMovies");
            //}
            //catch (Exception e)
            //{

            //    return this.View("NameError");
            //}

            return this.RedirectToAction("Movies");
        }

        public IActionResult Details(Guid id)
        {
            var viewModel = new DetailsMovieViewModel();
            viewModel = this._moviesService.GetById(id);

            return this.View(viewModel);
        }

        public IActionResult Movies(int currentIndex = 1)
        {
            int pageSize = 6;
            string controllerName = "Movies";
            string actionName = "Movies";
            var entities = this._moviesService.AllMovies();

            var viewModel = new RenderViewModel(
                currentIndex, 
                pageSize,
                controllerName,
                actionName,
                entities);

            return this.View(viewModel);
        }

        public IActionResult MoviesByCategory(string name, int currentIndex = 1)
        {
            ViewData["category"] = name;

            var entities = this._moviesCategoriesService
                .GetMoviesByCategory(name);

      
            int pageSize = 6;
            string controllerName = "Movies";
            string actionName = "MoviesByCategory";

            var viewModel = new RenderViewModel(currentIndex,
                pageSize,
                controllerName,
                actionName,
                entities);

            viewModel.SearchOption = name;

            return this.View(viewModel);
        }
    }
}