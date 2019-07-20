namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Series;
    using Services.DataServices.Contracts;
    using System.Threading.Tasks;
    using System;
    using Helpers.Contracts;

    public class SeriesController : Controller
    {
        private readonly ISeriesService _seriesService;
        private readonly IRenderService _renderService;

        public SeriesController(ISeriesService service,
            IRenderService renderService)
        {
            this._seriesService = service;
            this._renderService = renderService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateSerieViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSerieViewModel model)
        {
            var id = await this._seriesService.CreateSeries(model);
            return this.RedirectToAction("Details", new {id = id});
        }
        
        public IActionResult Details(Guid id)
        {
            var viewModel = this._seriesService.GetSeries(id);
            return this.View(viewModel);
        }

        public IActionResult Series(int currentIndex = 1)
        {
            
            var entities = this._seriesService.Series();
            var viewModel = this._renderService.GetViewModel(currentIndex,
                null,
                ControllerContext,
                entities);

            return this.View(viewModel);
        }

       
    }
}