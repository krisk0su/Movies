namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using ViewModels.AnimesEntities;
    using Services.DataServices.Contracts;
    using System.Threading.Tasks;
    using ViewModels.SeasonEpisodes;
    using Microsoft.AspNetCore.Authorization;


    public class AnimesEntitiesController : Controller
    {
        private readonly IAnimesEntitiesService _animesEntitiesService;

        public AnimesEntitiesController(IAnimesEntitiesService animesEntitiesService)
        {
            this._animesEntitiesService = animesEntitiesService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Guid animeId, string name, string poster)
        {
            var viewModel = new CreateAnimesEntityViewModel(animeId, name, poster);
            return this.View(viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnimesEntityViewModel model)
        {
            Console.WriteLine();
            var id = await this._animesEntitiesService.Create(model);
            return this.RedirectToAction("Episode", new {id = id});
        }

        //[Authorize(Roles = "Admin")]
        //public IActionResult Edit(int id)
        //{
        //    var viewModel = this._animesEntitiesService.GetToEdit(id);

        //    return null;
        //}
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