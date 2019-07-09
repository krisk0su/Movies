namespace MoviesApp.Services.DataServices.Contracts
{
    using ViewModels.SeriesEntities;
    using System.Threading.Tasks;

    public interface ISeriesEntityService
    {
        Task<int> Create(CreateSeriesEntityViewModel model);

        DetailsSeriesEntityViewModel GetById(int id);
    }
}
