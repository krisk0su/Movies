namespace MoviesApp.Data.Models.Animes
{
    using System;
    using Contracts;
    using Common;

    public class Anime:BaseModel<Guid>,IBaseEntity
    {
        public Anime()
        {
            this.Id = new Guid();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Trailer { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
    }
}
