using MoviesApp.Common.Animes;

namespace MoviesApp.Data.Models.Animes
{
    using Common;
    using Contracts;
    using System;
    
    public class AnimeEntity:BaseModel<int>,
        IAnimeEntity
    {
        public string Name { get; set; }
        public string Poster { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }

        public Guid AnimeId { get; set; }
        public virtual Anime Anime { get; set; }
    }
}
