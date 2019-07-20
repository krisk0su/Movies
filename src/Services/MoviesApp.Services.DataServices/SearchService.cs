namespace MoviesApp.Services.DataServices
{
    using Contracts;
    using MoviesApp.Data.Contracts;
    using Data.Models.Movies;
    using Data.Models.Series;
    using System.Collections.Generic;
    using MoviesApp.ViewModels.Contracts;
    using System.Linq;
    using System;
    using Data.Models.Animes;
    using Mapping;
    using ViewModels.Movies;
    using ViewModels.Series;
    using ViewModels.Animes;


    public class SearchService : ISearchService
    {
        private readonly IRepository<Movie> _moviesRepo;
        private readonly IRepository<Series> _seriesRepo;
        private readonly IRepository<Anime> _animesRepo;

        public SearchService(IRepository<Movie> moviesRepo,
            IRepository<Series> seriesRepo,
            IRepository<Anime> animesRepo)
        {
            this._moviesRepo = moviesRepo;
            this._seriesRepo = seriesRepo;
            this._animesRepo = animesRepo;
        }

        public IEnumerable<IDisplayable> Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Movie not found.");
            }

            var movies = this.GetMovies(name);
            var series = this.GetSeries(name);
            var animes = this.GetAnimes(name);

            var model = new List<IDisplayable>();

            model.AddRange(movies);
            model.AddRange(series);
            model.AddRange(animes);

            if (model.Count == 0)
            {
                throw new Exception("Movie not found.");
            }
            return model;
        }

        private IEnumerable<IDisplayable> GetMovies(string name)
        {
            return this._moviesRepo.All()
                .Where(x => x.Name == name || x.Name.Contains(name))
                .To<DisplayMovieViewModel>()
                .ToList();

        }
        private IEnumerable<IDisplayable> GetSeries(string name)
        {
            return this._seriesRepo.All()
                .Where(x => x.Name == name || x.Name.Contains(name))
                .To<DisplaySerieViewModel>()
                .ToList();
        }

        private IEnumerable<IDisplayable> GetAnimes(string name)
        {
            return this._animesRepo.All()
                .Where(x => x.Name == name || x.Name.Contains(name))
                .To<DisplayAnimeViewModel>()
                .ToList();
        }
    }
}
