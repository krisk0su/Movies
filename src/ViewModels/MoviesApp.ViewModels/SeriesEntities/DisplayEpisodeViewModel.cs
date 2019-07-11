namespace MoviesApp.ViewModels.SeriesEntities
{
    public class DisplayEpisodeViewModel
    {
        public DisplayEpisodeViewModel(int id, string name, string trailer,
            string poster,
            string link1,
            string link2)
        {
            this.Id = id;
            this.Name = name;
            this.Trailer = trailer;
            this.Poster = poster;
            this.Link1 = link1;
            this.Link2 = link2;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Poster { get; set; }

        public string Trailer { get; set; }

        public string Link1 { get; set; }

        public string Link2 { get; set; }
    }
}
