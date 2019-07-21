using System;
using System.Collections.Generic;

namespace MoviesApp.ViewModels.SeasonEpisodes
{
    public class SeasonTableViewModel
    {
        public SeasonTableViewModel(Guid seriesId, IEnumerable<int> seasons)
        {
            this.SeriesId = seriesId;
            this.Seasons = seasons;
        }
        public Guid SeriesId { get; set; }

        public IEnumerable<int> Seasons { get; set; }
    }
}
