using System;
using System.Collections.Generic;
using MoviesApp.Services.Mapping;
using MoviesApp.ViewModels.Movies;
using MoviesApp.ViewModels.Render;

namespace MoviesApp.Services.DataServices
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MoviesApp.Data.Contracts;
    using Data.Models;
    using Data.Models.Categories;
    using Contracts;

    public class MoviesCategoriesService:IMoviesCategoriesService
    {
        private IRepository<MoviesCategories> _repository;
        private ICategoryService _categoryService;

        public MoviesCategoriesService(IRepository<MoviesCategories> repo, 
            ICategoryService categoryService)
        {
            this._repository = repo;
            this._categoryService = categoryService;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            var categories = this._repository
                .All()
                .Include(x => x.Category)
                .Select(x => x.Category)
                .ToList();

            return categories;
        }

        public  IEnumerable<Category> MovieCategories(Guid id)
        {
            return this._repository
                .All()
                .Where(x => x.MovieId == id)
                .Select(x=> x.Category)
                .ToList();

        }

        public async Task Create(Guid movieId, IEnumerable<string> genres)
        {
            
            foreach (var genre in genres)
            {

                var item = new MoviesCategories()
                {
                    CategoryId = await this._categoryService.CreateCategory(genre),
                    MovieId = movieId
                };


                await this._repository.Add(item);

            }

        }

        public DisplayAllMoviesViewModel GetMoviesByCategory(string categoryName)
        {
            var movies = this._repository.All()
                .Include(x => x.Category)
                .Where(x => x.Category.Name == categoryName)
                .Select(x => x.Movie)
                .To<DisplayMovieViewModel>()
                .ToList();
            //TODO: must fix this
            var viewModel = new DisplayAllMoviesViewModel(movies, new RenderViewModel(1 ,1,
                "",""), 1);

            return viewModel;
        }
    }
}
