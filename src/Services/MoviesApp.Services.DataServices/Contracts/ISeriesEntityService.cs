namespace MoviesApp.Services.DataServices.Contracts
{
    using ViewModels.SeriesEntities;
    using System.Threading.Tasks;
    using System;

    public interface ISeriesEntityService
    {
        Task<int> Create(CreateSeriesEntityViewModel model);

        DetailsSeriesEntityViewModel GetById(int id);

        SeasonTableViewModel GetTable(Guid id);

        SeasonEntitiesViewModel GetSeasonEntities(CreateSeasonViewModel model);
    }
}
