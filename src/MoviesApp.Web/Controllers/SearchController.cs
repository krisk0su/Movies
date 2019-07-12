namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;
    using ViewModels.Render;


    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService search)
        {
            this._searchService = search;
        }

        public IActionResult Search(string name, int currentIndex = 1)
        {
            var entities = this._searchService.Search(name);

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