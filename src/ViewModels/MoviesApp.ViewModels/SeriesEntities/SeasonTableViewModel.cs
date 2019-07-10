namespace MoviesApp.ViewModels.SeriesEntities
{
    using System;
    using System.Collections.Generic;


    public class DisplaySeasonViewModel
    {
        public DisplaySeasonViewModel(Guid seriesId, IEnumerable<int> seasons)
        {
            this.SeriesId = seriesId;
            this.Seasons = seasons;
        }
        public Guid SeriesId { get; set; }

        public IEnumerable<int> Seasons { get; set; }
    }
}
