namespace MoviesApp.ViewModels.Pager
{
    using System;
    using Render;

    public class PagerViewModel
    {
        public PagerViewModel(RenderViewModel model, int totalItems)
        {
            // calculate total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)model.PageSize);
            var currentPage = model.CurrentPage;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = model.PageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            this.ControllerName = model.ControllerName;
            this.ActionName = model.ActionName;
        }
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
