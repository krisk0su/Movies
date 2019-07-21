namespace MoviesApp.ViewModels.SeasonEpisodes
{
    public class SeasonEntityViewModel
    {
        public SeasonEntityViewModel(int id, int season, int episode)
        {
            this.Id = id;
            this.Season = season;
            this.Episode = episode;
        }

        public int Id { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

    }
}
