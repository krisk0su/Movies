namespace MoviesApp.ViewModels.Movies
{
    using System.Collections.Generic;
    using Pager;
    using Render;
    using Contracts;


    public class DisplayAllMoviesViewModel
    {
        public DisplayAllMoviesViewModel(IEnumerable<IDisplayable> movies,
           RenderViewModel render,
           int totalItems
            )
        {
            this.Movies = movies;
            this.Pager = new PagerViewModel(render, totalItems);
        }
        public IEnumerable<IDisplayable> Movies { get; set; }
        public PagerViewModel Pager { get; set; }
        
    }
}
