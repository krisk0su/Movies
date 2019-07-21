using MoviesApp.ViewModels.SeasonEpisodes;

namespace MoviesApp.Services.DataServices.Contracts
{
    using ViewModels.SeriesEntities;
    using System.Threading.Tasks;
    using System;

    public interface ISeriesEntitiesService
    {
        Task<int> Create(CreateSeriesEntityViewModel model);

        DetailsSeriesEntityViewModel GetById(int id);

        SeasonTableViewModel GetTable(Guid id);

        SeasonEntitiesViewModel GetSeasonEntities(CreateSeasonViewModel model);

        DisplayEpisodeViewModel Episode(int id);
    }
}
