namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using ViewModels.AnimesEntities;
    using Services.DataServices.Contracts;
    using System.Threading.Tasks;


    public class AnimesEntitiesController : Controller
    {
        private readonly IAnimesEntitiesService _animesEntitiesService;

        public AnimesEntitiesController(IAnimesEntitiesService animesEntitiesService)
        {
            this._animesEntitiesService = animesEntitiesService;
        }
        public IActionResult Create(Guid animeId, string name, string poster)
        {
            var viewModel = new CreateAnimesEntityViewModel(animeId, name, poster);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Create(CreateAnimesEntityViewModel model)
        {
            var animeEntityId = await this._animesEntitiesService.Create(model);
            return null;
        }
    }
}