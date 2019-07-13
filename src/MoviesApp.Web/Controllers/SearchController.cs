namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.Render;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Contracts;

    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService search)
        {
            this._searchService = search;
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
           

            int pageSize = 6;
            string controllerName = "Search";
            string actionName = "Search";

            var viewModel = new RenderViewModel(currentIndex,
                pageSize,
                controllerName,
                actionName,
                entities);

            viewModel.SearchOption = name;

            return View(viewModel);
        }
    }
}