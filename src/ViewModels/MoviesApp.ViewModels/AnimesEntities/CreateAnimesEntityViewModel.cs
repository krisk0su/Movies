namespace MoviesApp.ViewModels.AnimesEntities
{
    using MoviesApp.Common.Animes;
    using System;

    public class CreateAnimesEntityViewModel:IAnimeEntity
    {
        public CreateAnimesEntityViewModel(Guid animeId, string name, string poster)
        {
            this.AnimeId = animeId;
            this.Name = name;
            this.Poster = poster;
        }
        public string Name { get; set; }
        public string Poster { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }

        public Guid AnimeId { get; set; }
    }
}
