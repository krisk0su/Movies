namespace MoviesApp.ViewModels.Contracts
{
    using System;

    public interface ISearchable
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Poster { get; set; }
        string Type { get; set; }
        double Rating { get; set; }
    }
}
