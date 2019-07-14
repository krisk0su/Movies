namespace MoviesApp.Data.Models.Movies
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using Common;

    public class Movie : BaseModel<Guid>, IMovie
    {
        public Movie()
        {
            this.MoviesCategories = new HashSet<MoviesCategories>();
            this.MoviesActors = new HashSet<MoviesActors>();
            this.Id = new Guid();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Trailer { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string ReleaseDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual HashSet<MoviesActors> MoviesActors { get; set; }

        public virtual HashSet<MoviesCategories> MoviesCategories { get; set; }


     
    }
}
