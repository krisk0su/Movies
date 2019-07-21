namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using ViewModels.AnimesEntities;
    using Services.DataServices.Contracts;
    using System.Threading.Tasks;
    using ViewModels.SeasonEpisodes;

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
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnimesEntityViewModel model)
        {
            Console.WriteLine();
            var id = await this._animesEntitiesService.Create(model);
            return this.RedirectToAction("Episode", new {id = id});
        }

        public IActionResult Season(Guid seriesId, int season)
        {
            var viewModel = new CreateSeasonViewModel(seriesId, season);
            return this.View(viewModel);
        }
        public IActionResult Episode(int id)
        {
            var viewModel = this._animesEntitiesService.Episode(id);
            return this.View(viewModel);
        }
    }
}