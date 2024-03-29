﻿namespace MoviesApp.ViewModels.Movies
{
   
    using System;
    using System.ComponentModel.DataAnnotations;
    using MoviesApp.Common.Movies;
    using Common;


    public class CreateMovieViewModel:IMovie, IGenre, IActors
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Trailer { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Actors { get; set; }

        public string ReleaseDate { get; set; }
      

        public DateTime CreatedOn { get; set; }

     
       

    }
}
