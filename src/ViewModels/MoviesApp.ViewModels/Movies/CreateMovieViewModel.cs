namespace MoviesApp.ViewModels.Movies
{
   
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateMovieViewModel 
    {
       
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string Poster { get; set; }
        [Required]
        public string Trailer { get; set; }

        public DateTime CreatedOn { get; set; }
        [Required]
        public double Rating { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Actors { get; set; }

        //Now categories are automatically updated from IMDB
        //public IList<string> Categories { get; set; }

        //public IEnumerable<SelectListItem> SelectList { get; set; }

    }
}
