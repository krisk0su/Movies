namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using Services.DataServices.Contracts;
    using ViewModels.SeriesEntities;
    using System.Threading.Tasks;
    using ViewModels.SeasonEpisodes;


    public class SeriesEntitiesController : Controller
    {
        private readonly ISeriesEntitiesService _seriesEntityService;

        public SeriesEntitiesController(ISeriesEntitiesService service)
        {
            this._seriesEntityService = service;
        }

        public IActionResult Create(Guid seriesId, string name ,string poster)
        {
            var viewModel = new CreateSeriesEntityViewModel(seriesId, name, poster);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSeriesEntityViewModel model)
        {
            int id = await this._seriesEntityService.Create(model);

            return this.RedirectToAction("Details", new {id = id});
        }

        public IActionResult Details(int id)
        {
            var viewModel = this._seriesEntityService.GetById(id);
            return this.View(viewModel);
        }

        public IActionResult Season(Guid seriesId, int season)
        {
           var viewModel = new CreateSeasonViewModel(seriesId, season);
           return this.View(viewModel);
        }

        public IActionResult Episode(int id)
        {
            var viewModel =  this._seriesEntityService.Episode(id);
            return this.View(viewModel);
        }
    }
}