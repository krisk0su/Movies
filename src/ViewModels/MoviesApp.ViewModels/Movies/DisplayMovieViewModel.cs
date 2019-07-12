namespace MoviesApp.ViewModels.Movies
{
    using AutoMapper;
    using MoviesApp.Data.Models.Movies;
    using System;
    using Services.Mapping;
    using Contracts;

    public class DisplayMovieViewModel:IDisplayable,IMapFrom<Movie>, IHaveCustomMapping
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Poster { get; set; }

        public double Rating { get; set; }

        public string Type { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DisplayMovieViewModel, Movie>()
                .ForMember(x => x.Id,
                    x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name,
                    x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Poster,
                    x => x.MapFrom(m => m.Poster))
                .ForMember(x => x.Rating,
                    x => x.MapFrom(m => m.Rating));
        }
    }
}
