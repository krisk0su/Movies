using MoviesApp.ViewModels.Contracts;

namespace MoviesApp.ViewModels.Render
{
    using System.Collections.Generic;

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
            this.SearchOption = string.Empty;
        }

        public int CurrentPage  { get; set; }
        public int PageSize { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string SearchOption { get; set; }
        public IEnumerable<IDisplayable> Entities { get; set; }
    }
}
