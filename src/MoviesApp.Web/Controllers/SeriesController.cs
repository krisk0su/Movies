namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Series;
    using ViewModels.Render;
    using ViewModels.SeriesEntities;
    using Services.DataServices.Contracts;
    using System.Threading.Tasks;
    using System;


    public class SeriesController : Controller
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService service)
        {
            this._seriesService = service;
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

        public IActionResult CreateEntity(Guid id)
        {
            var viewModel = new CreateSeriesEntityViewModel()
            {
                SeriesId = id
            };
           
            return this.View(viewModel);
        }
        [HttpPost]
        public IActionResult CreateEntity(CreateSeriesEntityViewModel model)
        {
            
            return this.Ok(model.SeriesId);
        }

        public IActionResult Series(int currentIndex = 1)
        {
            int pageSize = 3;
            var entities = this._seriesService.Series();
            var viewModel = new RenderViewModel(currentIndex,
                pageSize,
                "Series",
                "Series",
                entities);

            return this.View(viewModel);
        }

       
    }
}