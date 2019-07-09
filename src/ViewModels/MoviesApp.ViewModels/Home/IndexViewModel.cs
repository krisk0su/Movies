using System;
using System.Collections.Generic;
using System.Text;
using MoviesApp.ViewModels.Movies;

namespace MoviesApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.TopRated = new List<DetailsMovieViewModel>();
            this.Latest = new List<DetailsMovieViewModel>();
        }
        public IEnumerable<DetailsMovieViewModel> TopRated { get; set; }

        public IEnumerable<DetailsMovieViewModel> Latest { get; set; }


    }
}
