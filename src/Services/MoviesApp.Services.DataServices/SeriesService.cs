namespace MoviesApp.Services.DataServices
{
    using System;
    using System.Threading.Tasks;
    using MoviesApp.Data.Contracts;
    using Data.Models.Series;
    using Contracts;
    using ViewModels.Series;
    using System.Collections.Generic;
    using System.Linq;
    using Mapping;

    public class SeriesService:ISeriesService
    {
        private readonly IRepository<Series> _dbRepository;

        public SeriesService(IRepository<Series> repository)
        {
            this._dbRepository = repository;
        }
        public async Task<Guid> CreateSeries(CreateSerieViewModel model)
        {
            var series = new Series()
            {
                Name = model.Name,
                Description = model.Description,
                Poster = model.Poster,
                Rating = model.Rating,
                ReleaseDate = model.ReleaseDate,
                Genre = model.Genre,
                Actors = model.Actors
            };

            await this._dbRepository.Add(series);
            await this._dbRepository.SaveChangesAsync();

            return series.Id;
        }

        public DetailsSerieViewModel GetSeries(Guid id)
        {
            var series = this._dbRepository.All()
                .To<DetailsSerieViewModel>()
                .Single(x => x.Id == id);

            return series;
        }

        public IEnumerable<DisplaySerieViewModel> Series()
        {
            var series = this._dbRepository
                .All()
                .To<DisplaySerieViewModel>()
                .OrderBy(x => x.Rating)
                .ToList();

            return series;
        }
    }
}
