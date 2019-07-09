namespace MoviesApp.Data.Models.Movies
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;



    public class Movie : BaseModel<Guid>
    {
        public Movie()
        {
            this.MoviesCategories = new HashSet<MoviesCategories>();
            this.MoviesActors = new HashSet<MoviesActors>();
            this.Id = new Guid();
            this.CreatedOn = DateTime.UtcNow;
        }

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

        [Required]
        public double Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual HashSet<MoviesActors> MoviesActors { get; set; }

        public virtual HashSet<MoviesCategories> MoviesCategories { get; set; }

        
    }
}
