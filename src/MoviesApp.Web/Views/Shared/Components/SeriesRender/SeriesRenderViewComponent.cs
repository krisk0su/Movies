using MoviesApp.ViewModels.Series;

namespace MoviesApp.Web.Views.Shared.Components.SeriesRender
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.Render;
    using System.Linq;

    public class SeriesRenderViewComponent:ViewComponent
    {
        private readonly ISeriesService _seriesService;

        public SeriesRenderViewComponent(ISeriesService service)
        {
            this._seriesService = service;
        }

        public IViewComponentResult Invoke(RenderViewModel model)
        {
            int currentPage = model.CurrentPage;
            int pageSize = model.PageSize;

            var entities = this._seriesService.Series();
            var series = entities.Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            int totalItems = entities.Count();

            var viewModel = new DisplaySeriesViewModel(series, model, totalItems);
            return this.View("Default", viewModel);
        }
    }
}
