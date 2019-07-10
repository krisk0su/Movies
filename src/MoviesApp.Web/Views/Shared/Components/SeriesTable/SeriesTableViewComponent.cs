namespace MoviesApp.Web.Views.Shared.Components.SeriesTable
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using System;


    public class SeriesTableViewComponent:ViewComponent
    {
        private readonly ISeriesEntityService _SeriesService;

        public SeriesTableViewComponent(ISeriesEntityService service)
        {
            this._SeriesService = service;
        }

        public IViewComponentResult Invoke(Guid id)
        {
            var result = this._SeriesService.GetTable(id);

            return this.View("Default", result);
        }
    }
}
