namespace MoviesApp.Web.Views.Shared.Components.AnimesSeason
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.SeasonEpisodes;

    public class AnimesSeasonViewComponent:ViewComponent
    {
        private readonly IAnimesEntitiesService _animesEntityService;

        public AnimesSeasonViewComponent(IAnimesEntitiesService service)
        {
            this._animesEntityService = service;
        }

        public IViewComponentResult Invoke(CreateSeasonViewModel model)
        {
            var viewModel = this._animesEntityService.GetSeasonEntities(model);
            return this.View("Default", viewModel);
        }
    }
}
