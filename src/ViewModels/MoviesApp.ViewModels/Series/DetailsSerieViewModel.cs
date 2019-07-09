namespace MoviesApp.ViewModels.Series
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models.Series;
    using Services.Mapping;
    using AutoMapper;
    using Contracts;



    public class DetailsSerieViewModel : IMovie, IMapFrom<Series>, IHaveCustomMapping
    {
        public DetailsSerieViewModel()
        {
            this.Actors = new List<string>();
            this.Genre = new List<string>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public string ReleaseDate { get; set; }
        public double Rating { get; set; }

        public IEnumerable<string> Actors { get; set; }

        public IEnumerable<string> Genre { get; set; }

        public string DisplayCategories()
        {
            var result = string.Join(" ,",this.Genre);

            return result;
        }

        public string GetActors()
        {
            return string.Join(" ,", this.Actors);
        }
        public int GetStars()
        {
            var times = Convert.ToInt32(this.Rating);

            return times;
        }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Series, DetailsSerieViewModel>()
                .ForMember(x => x.Id,
                    x => x.MapFrom(s => s.Id))
                .ForMember(x => x.Name,
                    x => x.MapFrom(s => s.Name))
                .ForMember(x => x.Description,
                    x => x.MapFrom(s => s.Description))
                .ForMember(x => x.ReleaseDate,
                    x => x.MapFrom(s => s.ReleaseDate))
                .ForMember(x => x.Poster,
                    x => x.MapFrom(s => s.Poster))
                .ForMember(x => x.Rating,
                    x => x.MapFrom(s => s.Rating))
                .ForMember(x => x.Actors,
                    x => x.MapFrom(s => s.Actors
                        .Split(new char[] {','}).ToList()))
                .ForMember(x => x.Genre,
                    x => x.MapFrom(s => s.Genre
                        .Split(new char[] { ',' }).ToList()));
        }

    }
}
