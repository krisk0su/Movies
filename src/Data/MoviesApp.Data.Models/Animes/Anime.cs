﻿namespace MoviesApp.Data.Models.Animes
{
    using System;
    using Contracts;
    using Common;
    using System.Collections.Generic;

    public class Anime:BaseModel<Guid>,
        IAnime
    {
        public Anime()
        {
            this.Id = new Guid();
            this.AnimeEntities = new List<AnimeEntity>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }

        public virtual IEnumerable<AnimeEntity> AnimeEntities { get; set; }
    }
}
