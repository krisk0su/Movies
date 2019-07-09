namespace MoviesApp.Services.DataServices.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models.Categories;
    using ViewModels.Movies;

    public interface IMoviesCategoriesService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> MovieCategories(Guid id);
        Task Create(Guid movieId, IEnumerable<string> genres);
        DisplayAllMoviesViewModel GetMoviesByCategory(string name);
    }
}
