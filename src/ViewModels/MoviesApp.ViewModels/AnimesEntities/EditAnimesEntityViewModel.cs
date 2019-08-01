namespace MoviesApp.ViewModels.AnimesEntities
{
    using MoviesApp.Common.Animes;

    public class EditAnimesEntityViewModel:IAnimeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
    }
}
