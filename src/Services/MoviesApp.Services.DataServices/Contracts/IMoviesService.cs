using System.Linq;
using MoviesApp.Data.Models.Movies;
using MoviesApp.ViewModels.Home;

namespace MoviesApp.Services.DataServices.Contracts
{
    using System;
    using System.Collections.Generic;
    using ViewModels.Movies;
    using System.Threading.Tasks;

    public interface IMoviesService
    {
        Task<Guid> Create(CreateMovieViewModel model);

        DetailsMovieViewModel GetById(Guid id);

        IEnumerable<DisplayMovieViewModel> AllMovies();
 
        IndexViewModel IndexMovies();
    }
}
