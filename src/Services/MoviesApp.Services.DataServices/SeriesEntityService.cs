
using System.Linq;

namespace MoviesApp.Services.DataServices
{
    using System.Threading.Tasks;
    using Contracts;
    using ViewModels.SeriesEntities;
    using MoviesApp.Data.Contracts;
    using Data.Models.Series;

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
    }
}
