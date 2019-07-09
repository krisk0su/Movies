namespace MoviesApp.ViewModels.Series
{
    using System.Collections.Generic;
    using Pager;
    using Render;

    public class DisplaySeriesViewModel
    {
        public DisplaySeriesViewModel(IEnumerable<DisplaySerieViewModel> series,
            RenderViewModel render,
            int totalItems)
        {
            this.Series = series;
            this.Pager = new PagerViewModel(render, totalItems);
        }
        public IEnumerable<DisplaySerieViewModel> Series { get; set; }
        public PagerViewModel Pager { get; set; }
    }
}
