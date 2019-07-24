namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.Animes;
    using System.Threading.Tasks;
    using System;
    using Helpers.Contracts;
    using Microsoft.AspNetCore.Authorization;

    public class AnimesController : Controller
    {
        private readonly IAnimesService _animesService;
        private readonly IRenderService _renderService;

        public AnimesController(IAnimesService animesService, 
            IRenderService renderService)
        {
            this._animesService = animesService;
            this._renderService = renderService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var viewModel = new CreateAnimeViewModel();
            return View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnimeViewModel model)
        {
            var id = await this._animesService.Create(model);

            return this.RedirectToAction("Details", new {id = id});

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Guid id)
        {

            return this.Content("trying to edit");
        }
        public IActionResult Details(Guid id)
        {
            var viewModel = this._animesService.GetAnimeDetails(id);
            return this.View(viewModel);
        }

        public IActionResult Animes(int currentIndex = 1)
        {
            var entities = this._animesService.GetAllAnimes();

            var viewModel = this._renderService.GetViewModel(currentIndex,
                null,
                ControllerContext,
                entities);

            return this.View(viewModel);
        }
    }
}