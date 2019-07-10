using System.Collections.Generic;

namespace MoviesApp.Services.DataServices
{
    using System.Threading.Tasks;
    using Contracts;
    using ViewModels.SeriesEntities;
    using MoviesApp.Data.Contracts;
    using Data.Models.Series;
    using System.Linq;
    using System;


    public class SeriesEntityService:ISeriesEntityService
    {
        private readonly IRepository<SeriesEntity> _repository;

        public SeriesEntityService(IRepository<SeriesEntity> repository)
        {
            this._repository = repository;
        }
        public async Task<int> Create(CreateSeriesEntityViewModel model)
        {
            var name = $"{model.Name} - S_{model.Season} - Ep_{model.Episode}";

            var seriesEntity = new SeriesEntity()
            {
                Name = name,
                Episode = model.Episode,
                Season = model.Season,
                Poster = model.Poster,
                Trailer = model.Trailer,
                SeriesId = model.SeriesId
            };

            await this._repository.Add(seriesEntity);
            await this._repository.SaveChangesAsync();

            return seriesEntity.Id;
        }

        public DetailsSeriesEntityViewModel GetById(int id)
        {
            var seriesEntity = this._repository
                .All()
                .Single(x => x.Id == id);

            var viewModel = new DetailsSeriesEntityViewModel()
            {
                Id = seriesEntity.Id,
                Name = seriesEntity.Name,
                Poster = seriesEntity.Poster,
                Trailer = seriesEntity.Trailer,
                Link1 = seriesEntity.Link1,
                Link2 = seriesEntity.Link2 ?? "",
            };

            return viewModel;
        }

        public SeasonTableViewModel GetTable(Guid id)
        {
            var result = this._repository.All()
                .Where(x => x.SeriesId == id)
                .GroupBy(x => x.Season)
                .Select(x => x.Key)
                .ToList();

            var viewModel = new SeasonTableViewModel(id, result);
            return viewModel;
        }

        public SeasonEntitiesViewModel GetSeasonEntities(CreateSeasonViewModel model)
        {
            var entities = this._repository.All()
                .Where(x => x.SeriesId == model.SeriesId && x.Season == model.Season)
                .OrderBy(x => x.Season)
                .ToList();

            var tempCollection = new List<SeasonEntityViewModel>();

            foreach (var entity in entities)
            {
                var temp = new SeasonEntityViewModel(entity.Id, 
                    entity.Season,
                    entity.Episode);

                tempCollection.Add(temp);
            }

            var viewModel = new SeasonEntitiesViewModel();

        }
    }
}
