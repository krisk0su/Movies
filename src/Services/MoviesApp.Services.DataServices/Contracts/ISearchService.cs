namespace MoviesApp.Services.DataServices.Contracts
{
    using MoviesApp.ViewModels.Search;

    public interface ISearchService
    {
        DisplaySearchViewModel Search(string name);
    }
}
