namespace MoviesApp.Services.DataServices.Contracts
{
    using ViewModels.AnimesEntities;
    using System.Threading.Tasks;

    public interface IAnimesEntitiesService
    {
        Task<int> Create(CreateAnimesEntityViewModel model);
    }
}
