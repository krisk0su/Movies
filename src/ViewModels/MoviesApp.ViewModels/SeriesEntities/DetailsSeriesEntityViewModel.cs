using MoviesApp.Common;

namespace MoviesApp.ViewModels.SeriesEntities
{
    public class DetailsSeriesEntityViewModel:ILink, INameable
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public string Poster { get; set; }

        public string Trailer { get; set; }

        public string Link1 { get; set; }
        public string Link2 { get; set; }
    }
}
