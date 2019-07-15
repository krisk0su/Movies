namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Contracts;
    using Helpers.Contracts;

    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IRenderService _renderService;

        public SearchController(ISearchService search,
            IRenderService renderService)
        {
            this._searchService = search;
            this._renderService = renderService;
        }

        public IActionResult Search(string name, int currentIndex = 1)
        {
            var entities = new List<IDisplayable>();

            try
            {
                entities = this._searchService.Search(name).ToList();
            }
            catch (Exception ex)
            {
                return this.View("NotFound", ex.Message);
            }

            var viewModel = this._renderService.GetViewModel(currentIndex,
                name,
                ControllerContext,
                entities);

            return View(viewModel);
        }
    }
}