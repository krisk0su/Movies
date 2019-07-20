using MoviesApp.Common.Series;

namespace MoviesApp.Data.Models.Series
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    
    public class Series: BaseModel<Guid>, 
        ISerie
    {
        public Series()
        {
            this.Id = new Guid();
            this.SeriesEntity = new List<SeriesEntity>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }

        public string ReleaseDate { get; set; }

        public string Actors { get; set; }

        public string Genre { get; set; }

        public virtual IEnumerable<SeriesEntity> SeriesEntity { get; set; }

     
    }
}
