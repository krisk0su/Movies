namespace MoviesApp.ViewModels.SeriesEntities
{
    using System;
    using MoviesApp.Common.Series;

    public class CreateSeriesEntityViewModel:ISeriesEntity
    {
        public CreateSeriesEntityViewModel()
        {
            
        }
        public CreateSeriesEntityViewModel(Guid seriesId, string name, string poster)
        {
            this.SeriesId = seriesId;
            this.Name = name;
            this.Poster = poster;
        }
        public string Name { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
        public string Trailer { get; set; }
        public string Poster { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }

        public Guid SeriesId { get; set; }

    }
}
