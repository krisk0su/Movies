namespace MoviesApp.Web.Views.Shared.Components.AnimesTable
{
    using Microsoft.AspNetCore.Mvc;

    public class AnimesTableViewComponent:ViewComponent
    {
        public AnimesTableViewComponent()
        {
            
        }

        public IViewComponentResult Invoke()
        {

            return this.View("Default");
        }
    }
}
