namespace MoviesApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.DataServices.Contracts;

    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        //[BindProperty]
        //public string name { get; set; }

        public SearchController(ISearchService search)
        {
            this._searchService = search;
        }

        [HttpPost]
        public IActionResult Search(string name)
        {

            var viewModel = this._searchService.Search(name);
            return View(viewModel);
        }
    }
}