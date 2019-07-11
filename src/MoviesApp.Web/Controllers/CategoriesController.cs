using MoviesApp.ViewModels.Render;

namespace MoviesApp.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMoviesCategoriesService _moviesCategoriesService;

        public CategoriesController(ICategoryService service,
            IMoviesCategoriesService mvService)
        {
            this._categoryService = service;
            this._moviesCategoriesService = mvService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new CreateCategoryViewModel();

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var categoryId = await this._categoryService.Create(vm);
            return this.RedirectToAction("Details", new  {id = categoryId});
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Details(string id)
        {
            var viewModel = this._categoryService.Details(id);
            return this.View(viewModel);
        }

        
        public IActionResult MoviesByCategory(string name)
        {
            ViewData["category"] = name;
            var entities = this._moviesCategoriesService
                .GetMoviesByCategory(name);
            int currentIndex = 1;
            int pageSize = 6;
            string controllerName = "Movies";
            string actionName = "Movies";

            var viewModel = new RenderViewModel(currentIndex,
                pageSize,
                controllerName,
                actionName,
                entities);

            return this.View(viewModel);
        }
    }
}