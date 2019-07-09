namespace MoviesApp.Services.DataServices
{
    using Contracts;
    using ViewModels.Search;
    using MoviesApp.Data.Contracts;
    using Data.Models.Movies;
    using Data.Models.Series;
    using System.Collections.Generic;
    using MoviesApp.ViewModels.Contracts;
    using System.Linq;

    public class SearchService:ISearchService
    {
        private readonly IRepository<Movie> _moviesRepo;
        private readonly IRepository<Series> _seriesRepo;

        public SearchService(IRepository<Movie> moviesRepo,
            IRepository<Series> seriesRepo)
        {
            this._moviesRepo = moviesRepo;
            this._seriesRepo = seriesRepo;
        }
        public DisplaySearchViewModel Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            var movies = this.MoviesSearch(name);
            var series = this.SeriesSearch(name);

            var viewModel = new DisplaySearchViewModel();

            viewModel.Results.AddRange(movies);
            viewModel.Results.AddRange(series);

            if (viewModel.Results.Count == 0)
            {
               return null;
            }
            return viewModel;
        }

        private IEnumerable<ISearchable> MoviesSearch(string name)
        {
            var results = this._moviesRepo.All()
                .Where(x => x.Name == name || x.Name.Contains(name))
                .ToList();

            var searches = new List<ISearchable>();

            foreach (var result in results)
            {
                var search = new SearchViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Poster = result.Poster,
                    Rating = result.Rating,
                    Type = "Movies"
                };

                searches.Add(search);
            }

            return searches;
        }
        private IEnumerable<ISearchable> SeriesSearch(string name)
        {
            var results = this._seriesRepo.All()
                .Where(x => x.Name == name || x.Name.Contains(name))
                .ToList();

            var searches = new List<ISearchable>();

            foreach (var result in results)
            {
                var search = new SearchViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Poster = result.Poster,
                    Rating = result.Rating,
                    Type = "Series"
                };

                searches.Add(search);
            }

            return searches;
        }
    }
}
