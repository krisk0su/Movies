namespace MoviesApp.ViewModels.Movies
{
    using System.Collections.Generic;
    using Pager;
    using Render;
    
    public class DisplayAllMoviesViewModel
    {
        public DisplayAllMoviesViewModel(IEnumerable<DisplayMovieViewModel> movies,
           RenderViewModel render,
           int totalItems
            )
        {
            this.Movies = movies;
            this.Pager = new PagerViewModel(render, totalItems);
        }
        public IEnumerable<DisplayMovieViewModel> Movies { get; set; }
        public PagerViewModel Pager { get; set; }
        
    }
}
