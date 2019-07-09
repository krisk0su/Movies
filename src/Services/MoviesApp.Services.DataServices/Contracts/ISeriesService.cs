using System.Collections.Generic;

namespace MoviesApp.Services.DataServices.Contracts
{
    using ViewModels.Series;
    using System;
    using System.Threading.Tasks;

    public interface ISeriesService
    {
        Task<Guid> CreateSeries(CreateSerieViewModel model);

        DetailsSerieViewModel GetSeries(Guid id);

        IEnumerable<DisplaySerieViewModel> Series();
    }
}
