namespace MoviesApp.Web.Views.Shared.Components.Pager
{
    using Microsoft.AspNetCore.Mvc;
    using MoviesApp.ViewModels.Pager;
    using Helpers.Contracts;


    public class PagerViewComponent:ViewComponent
    {
        private readonly IPagerService _pagerService;

        public PagerViewComponent(IPagerService pagerService)
        {
            this._pagerService = pagerService;
        }
        public IViewComponentResult Invoke(PagerViewModel pager) 
        {
          
            string viewName = this._pagerService.GetViewName(pager.ActionName);

            return this.View(viewName, pager);
        }
    }
}
