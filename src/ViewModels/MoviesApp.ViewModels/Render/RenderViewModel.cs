namespace MoviesApp.ViewModels.Render
{
    public class RenderViewModel
    {
        public RenderViewModel(int currentPage,
            int pageSize,
            string controllerName,
            string actionName)
        {
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.ControllerName = controllerName;
            this.ActionName = actionName;
        }

        public int CurrentPage  { get; set; }
        public int PageSize { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
