namespace MoviesApp.Data.Models.Series
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class Series: BaseModel<Guid>
    {
        public Series()
        {
            this.Id = new Guid();
        }
        public string Name { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }

        public string Poster { get; set; }

        public string ReleaseDate { get; set; }

        public string Actors { get; set; }

        public string Genre { get; set; }

        public virtual IEnumerable<SeriesEntity> SeriesEntity { get; set; }
    }
}
