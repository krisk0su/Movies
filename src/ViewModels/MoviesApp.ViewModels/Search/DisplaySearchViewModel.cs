namespace MoviesApp.ViewModels.Search
{
    using System.Collections.Generic;
    using Contracts;

    public class DisplaySearchViewModel
    {
        public DisplaySearchViewModel()
        {
            this.Results = new List<ISearchable>();
        }
        public List<ISearchable> Results { get; set; }
    }
}
