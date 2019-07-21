using MoviesApp.ViewModels.SeriesEntities;

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
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnimesEntityViewModel model)
        {
            Console.WriteLine();
            var id = await this._animesEntitiesService.Create(model);
            return this.RedirectToAction("Details", new {id = id});
        }

        public IActionResult Details(int id)
        {
            return this.Content("creted");
        }

        public IActionResult GetSeason(Guid seriesId, int season)
        {
            var viewModel = new CreateSeasonViewModel(seriesId, season);
            return this.View(viewModel);
        }
    }
}