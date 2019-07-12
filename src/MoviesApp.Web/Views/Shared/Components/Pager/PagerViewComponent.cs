namespace MoviesApp.Web.Views.Shared.Components.Pager
{
    using Microsoft.AspNetCore.Mvc;
    using MoviesApp.ViewModels.Pager;

    public class PagerViewComponent:ViewComponent
    {
        
        public IViewComponentResult Invoke(PagerViewModel pager) 
        {
            if (pager.ActionName == "MoviesByCategory" 
                || pager.ActionName == "Search")
            {
                return this.View("MoviesCateogires", pager);
            }

            return this.View("Default",pager);
        }
        
    }
}
