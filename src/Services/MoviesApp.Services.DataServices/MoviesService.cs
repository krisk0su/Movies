namespace MoviesApp.Services.DataServices
{
    using System;
    using System.Linq;
    using MoviesApp.Data.Contracts;
    using System.Threading.Tasks;
    using Contracts;
    using System.Collections.Generic;
    using Data.Models.Movies;
    using Mapping;
    using ViewModels.Home;
    using ViewModels.Movies;
    using MoviesApp.ViewModels.Contracts;


    public class MoviesService: IMoviesService
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMoviesCategoriesService _moviesCategoriesService;
        private IMoviesActorsService _moviesActorsService;

        public MoviesService(IRepository<Movie> repository,
            IMoviesCategoriesService moviesCategoriesService,
            IMoviesActorsService moviesActorsService)
        {
            this._repository = repository;
            this._moviesCategoriesService = moviesCategoriesService;
            this._moviesActorsService = moviesActorsService;
        }

        public async Task<Guid> Create(CreateMovieViewModel model)
        {
            var movie = new Movie()
            {
                Name = model.Name,
                Description = model.Description,
                Trailer = model.Trailer,
                Link1 = model.Link1,
                Link2 = model.Link2,
                Poster = model.Poster,
                Rating = model.Rating,
                ReleaseDate = model.ReleaseDate
            };

            IEnumerable<string> genres = model.Genre
                .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            IEnumerable<string> actors = model.Actors
                .Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);

            await this._repository.Add(movie);
            await this._moviesCategoriesService.Create(movie.Id, genres);
            await this._moviesActorsService.Create(movie.Id, actors);
            await this._repository.SaveChangesAsync();

            return movie.Id;
        }

        public DetailsMovieViewModel GetById(Guid id)
        {
            var vm = this._repository
                .All()
                .To<DetailsMovieViewModel>()
                .Single(x=> x.Id == id);

            var categories = this._moviesCategoriesService.MovieCategories(id);

            vm.Categories = categories;
            vm.Actors = this._moviesActorsService.Actors(vm.Id);
            return vm;

        }

        public IEnumerable<IDisplayable> AllMovies()
        {
            var movies = this._repository
                .All()
                .To<DisplayMovieViewModel>()
                .OrderBy(x => x.Rating)
                .ToList();

            return movies;
        }

        public IndexViewModel IndexMovies()
        {
            //TODO: TOP RATED

            var latest = this._repository
                .All()
                .To<DetailsMovieViewModel>()
                .ToList();

            var vm = new IndexViewModel(){Latest = latest, TopRated = latest};

            return vm;
        }

        public CreateMovieViewModel GetToEdit(Guid id)
        {
            var movie = this._repository.All()
                .Single(x => x.Id == id);

            var viewModel = new CreateMovieViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                Poster = movie.Poster,
                Rating = movie.Rating,
                Link1 = movie.Link1,
                Link2 = movie.Link2,
                Actors = string.Join(",", movie.MoviesActors.Select(x=> x.Actor.Name)),
                Genre = string.Join(", ", movie.MoviesCategories.Select(x=> x.Category.Name))

            };

            return viewModel;
        }

        public async Task<Guid> Update(CreateMovieViewModel model)
        {
            var movie = this._repository.All()
                .Single(x => x.Id == model.Id);

            movie.Name = model.Name;
            movie.Description = model.Description;
            movie.Poster = model.Poster;
            movie.Rating = model.Rating;
            movie.Link1 = model.Link1;
            movie.Link2 = model.Link2;
            movie.Trailer = model.Trailer;
            movie.ReleaseDate = model.ReleaseDate;

            this._repository.Update(movie);
            await this._repository.SaveChangesAsync();

            return movie.Id;
        }
    }
}
