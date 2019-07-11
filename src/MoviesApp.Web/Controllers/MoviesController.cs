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
        private ICategoryService _categoryService;

        public MoviesController(IMoviesService moviesService, ICategoryService category)
        {
            this._moviesService = moviesService;
            this._categoryService = category;
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
    }
}