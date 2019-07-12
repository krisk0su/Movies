namespace MoviesApp.Services.DataServices.Contracts
{
    using System.Collections.Generic;
    using MoviesApp.ViewModels.Contracts;

    public interface ISearchService
    {
        IEnumerable<IDisplayable> Search(string name);
    }
}
