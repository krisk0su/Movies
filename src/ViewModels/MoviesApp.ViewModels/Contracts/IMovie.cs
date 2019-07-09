namespace MoviesApp.ViewModels.Contracts
{
    using System;

    public interface IMovie
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Poster { get; set; }
        string ReleaseDate { get; set; }
        double Rating { get; set; }
    }
}
