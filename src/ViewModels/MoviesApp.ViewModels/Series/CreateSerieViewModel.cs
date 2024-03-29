﻿namespace MoviesApp.ViewModels.Series
{
    using MoviesApp.Common.Series;

    public class CreateSerieViewModel:ISerie
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }

        public string ReleaseDate { get; set; }

        public string Actors { get; set; }

        public string Genre { get; set; }
  
    }
}
