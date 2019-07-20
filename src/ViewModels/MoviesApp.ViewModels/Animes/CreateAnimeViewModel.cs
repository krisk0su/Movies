namespace MoviesApp.ViewModels.Animes
{
    using MoviesApp.Common.Animes;

    public class CreateAnimeViewModel:IAnime
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string ReleaseDate { get; set; }
    }
}
