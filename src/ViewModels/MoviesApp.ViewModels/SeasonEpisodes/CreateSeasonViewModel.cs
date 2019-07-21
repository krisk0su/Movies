namespace MoviesApp.ViewModels.SeasonEpisodes
{
    using System;


    public class CreateSeasonViewModel
    {
        public CreateSeasonViewModel(Guid id, int season)
        {
            this.Season = season;
            this.Id = id;
        }

        public Guid Id { get; set; }
        public int Season { get; set; }
    }
}
