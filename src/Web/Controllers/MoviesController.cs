namespace MoviesApp.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.Movies;
    using Microsoft.AspNetCore.Authorization;
    using Helpers.Contracts;


    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        private readonly IMoviesCategoriesService _moviesCategoriesService;
        private readonly IRenderService _renderService;

        public MoviesController(IMoviesService moviesService,
            IMoviesCategoriesService mvService,
            IRenderService renderService)
        {
            this._moviesService = moviesService;
            this._moviesCategoriesService = mvService;
            this._renderService = renderService;
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
    
            try
            {
                var movieId = await this._moviesService.Create(model);
                return this.RedirectToAction("AllMovies");
            }
            catch (Exception e)
            {

                return this.View("NameError");
            }

           
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Guid id)
        {
            var viewModel = _moviesService.GetToEdit(id);
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditMovieViewModel model)
        {
            var id = await this._moviesService.Update(model);
            return this.RedirectToAction("Details", new {id = id});
        }

        public IActionResult Details(Guid id)
        {
            var viewModel = new DetailsMovieViewModel();
            viewModel = this._moviesService.GetById(id);

            return this.View(viewModel);
        }

        [Route("")]
        [Route("/home")]
        public IActionResult Movies(int currentIndex = 1)
        {
            var entities = this._moviesService.AllMovies();

            var viewModel = this._renderService.GetViewModel(currentIndex,
                null,
                ControllerContext,
                entities);


            return this.View(viewModel);
        }

        public IActionResult MoviesByCategory(string name, int currentIndex = 1)
        {
            ViewData["category"] = name;

            var entities = this._moviesCategoriesService
                .GetMoviesByCategory(name);

            var viewModel = this._renderService.GetViewModel(currentIndex,
                name,
                ControllerContext,
                entities);


            return this.View(viewModel);
        }
    }
}