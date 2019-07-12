namespace MoviesApp.ViewModels.Contracts
{
    using System;

    public interface IDisplayable
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Poster { get; set; }

        double Rating { get; set; }

        string Type { get; set; }
    }
}
