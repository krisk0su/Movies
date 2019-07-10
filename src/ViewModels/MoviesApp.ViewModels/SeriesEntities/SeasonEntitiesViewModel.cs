namespace MoviesApp.ViewModels.SeriesEntities
{
    using System.Collections.Generic;

    public class SeasonEntitiesViewModel
    {
        public SeasonEntitiesViewModel(IEnumerable<SeasonEntityViewModel> entities)
        {
            this.Entities = entities;
        }

        public IEnumerable<SeasonEntityViewModel> Entities { get; set; }
    }
}
