using System.Collections.Generic;
using MoviesApp.ViewModels.SeriesEntities;

namespace MoviesApp.ViewModels.SeasonEpisodes
{
    public class SeasonEntitiesViewModel
    {
        public SeasonEntitiesViewModel(IEnumerable<SeasonEntityViewModel> entities)
        {
            this.Entities = entities;
        }

        public IEnumerable<SeasonEntityViewModel> Entities { get; set; }
    }
}
