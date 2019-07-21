namespace MoviesApp.Web.Views.Shared.Components.AnimesTable
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using System;

    public class AnimesTableViewComponent:ViewComponent
    {
        private readonly IAnimesEntitiesService _animesEntityService;

        public AnimesTableViewComponent(IAnimesEntitiesService service)
        {
            this._animesEntityService = service;
        }

        public IViewComponentResult Invoke(Guid id)
        {
            var viewModel = this._animesEntityService.GetTable(id);
            return this.View("Default", viewModel);
        }
    }
}
