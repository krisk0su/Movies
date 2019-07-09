namespace MoviesApp.Web.Views.Shared.Components.Pager
{
    using Microsoft.AspNetCore.Mvc;
    using MoviesApp.ViewModels.Pager;

    public class PagerViewComponent:ViewComponent
    {
        
        public IViewComponentResult Invoke(PagerViewModel pager) 
        {
            return this.View("Default",pager);
        }
        
    }
}
