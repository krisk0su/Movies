namespace MoviesApp.ViewModels.SeriesEntities
{
    using System;

    public class CreateSeasonViewModel
    {
        public CreateSeasonViewModel(Guid seriesId, int season)
        {
            this.Season = season;
            this.SeriesId = seriesId;
        }

        public Guid SeriesId { get; set; }
        public int Season { get; set; }
    }
}
