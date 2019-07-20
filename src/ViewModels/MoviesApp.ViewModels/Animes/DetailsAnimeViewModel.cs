﻿namespace MoviesApp.ViewModels.Animes
{
    using MoviesApp.Common.Animes;
    using System;

    public class DetailsAnimeViewModel:IAnime
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string ReleaseDate { get; set; }

        public int GetStars()
        {
            var times = Convert.ToInt32(this.Rating);

            return times;
        }
    }
}
