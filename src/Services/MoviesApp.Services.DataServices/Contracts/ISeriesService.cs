namespace MoviesApp.Services.DataServices.Contracts
{
    using ViewModels.Series;
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MoviesApp.ViewModels.Contracts;

    public interface ISeriesService
    {
        Task<Guid> CreateSeries(CreateSerieViewModel model);

        DetailsSerieViewModel GetSeries(Guid id);

        IEnumerable<IDisplayable> Series();
    }
}
