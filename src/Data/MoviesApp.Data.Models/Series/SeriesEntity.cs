namespace MoviesApp.Data.Models.Series
{
    using Contracts;
    using System;
    using Common;

    public class SeriesEntity: BaseModel<int>,
        ILink,
        INameable
    {
        public string Name { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }

        public string Trailer { get; set; }

        public string Poster { get; set; }

        public string Link1 { get; set; }

        public string Link2 { get; set; }

        public Guid SeriesId { get; set; }
        public virtual Series Series { get; set; }
    }

 
}
