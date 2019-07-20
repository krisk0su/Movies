namespace MoviesApp.ViewModels.Search
{
    using Contracts;
    using System;
    
    public class SearchViewModel:IDisplayable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Type { get; set; }
    }
}
