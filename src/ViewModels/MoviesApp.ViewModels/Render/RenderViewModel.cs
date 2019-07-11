using System.Collections.Generic;
using MoviesApp.ViewModels.Contracts;

namespace MoviesApp.ViewModels.Render
{
    public class RenderViewModel
    {
        public RenderViewModel(int currentPage,
            int pageSize,
            string controllerName,
            string actionName,
            IEnumerable<IDisplayable> entities)
        {
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.ControllerName = controllerName;
            this.ActionName = actionName;
            this.Entities = entities;
        }

        public int CurrentPage  { get; set; }
        public int PageSize { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public IEnumerable<IDisplayable> Entities { get; set; }
    }
}
