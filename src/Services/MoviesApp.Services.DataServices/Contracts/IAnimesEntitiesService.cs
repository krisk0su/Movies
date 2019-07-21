namespace MoviesApp.Services.DataServices.Contracts
{
    using ViewModels.AnimesEntities;
    using ViewModels.SeriesEntities;
    using System.Threading.Tasks;
    using System;
    
    public interface IAnimesEntitiesService
    {
        Task<int> Create(CreateAnimesEntityViewModel model);

        SeasonTableViewModel GetTable(Guid id);

        SeasonEntitiesViewModel GetSeasonEntities(CreateSeasonViewModel model);
    }
}
