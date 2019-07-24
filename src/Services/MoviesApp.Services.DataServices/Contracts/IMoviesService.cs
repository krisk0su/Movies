namespace MoviesApp.Services.DataServices.Contracts
{
    using System;
    using System.Collections.Generic;
    using ViewModels.Movies;
    using System.Threading.Tasks;
    using ViewModels.Home;
    using MoviesApp.ViewModels.Contracts;

    public interface IMoviesService
    {
        Task<Guid> Create(CreateMovieViewModel model);

        DetailsMovieViewModel GetById(Guid id);

        IEnumerable<IDisplayable> AllMovies();
 
        IndexViewModel IndexMovies();

        EditMovieViewModel GetToEdit(Guid id);

        Task<Guid> Update(EditMovieViewModel model);
    }
}
