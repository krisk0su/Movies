namespace MoviesApp.Web.Views.Shared.Components.SeriesSeason
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.SeriesEntities;

    public class SeriesSeasonViewComponent:ViewComponent
    {
        private readonly ISeriesEntityService _seriesEntityService;

        public SeriesSeasonViewComponent(ISeriesEntityService service)
        {
            this._seriesEntityService = service;
        }

        public IViewComponentResult Invoke(CreateSeasonViewModel model)
        {
            var viewModel = this._seriesEntityService.GetSeasonEntities(model);
            return this.View("Default", viewModel);
        }
    }
}
