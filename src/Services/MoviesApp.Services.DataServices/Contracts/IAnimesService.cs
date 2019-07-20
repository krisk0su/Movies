namespace MoviesApp.Services.DataServices.Contracts
{
    using System.Threading.Tasks;
    using System;
    using ViewModels.Animes;
    using System.Collections.Generic;
    using MoviesApp.ViewModels.Contracts;

    public interface IAnimesService
    {
        Task<Guid> Create(CreateAnimeViewModel model);

        DetailsAnimeViewModel GetAnimeDetails(Guid id);

        IEnumerable<IDisplayable> GetAllAnimes();

    }
}
