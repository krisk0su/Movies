namespace MoviesApp.ViewModels.Movies
{
    using Common;
    using MoviesApp.Common.Movies;
    using System;


    public class EditMovieViewModel:IMovie,IGenre, IActors
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Trailer { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
    }
}
