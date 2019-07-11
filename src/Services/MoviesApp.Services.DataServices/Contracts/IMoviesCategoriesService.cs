namespace MoviesApp.Services.DataServices.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models.Categories;
    using MoviesApp.ViewModels.Contracts;

    public interface IMoviesCategoriesService
    {
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> MovieCategories(Guid id);
        Task Create(Guid movieId, IEnumerable<string> genres);
        IEnumerable<IDisplayable> GetMoviesByCategory(string name);
    }
}
