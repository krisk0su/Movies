namespace MoviesApp.ViewModels.Animes
{
    using Contracts;
    using System;
    using AutoMapper;
    using MoviesApp.Data.Models.Animes;
    using Services.Mapping;

    public class DisplayAnimeViewModel:IDisplayable, IMapFrom<Anime>, IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Type { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Anime, DisplayAnimeViewModel>()
                .ForMember(x => x.Id,
                    x => x.MapFrom(a => a.Id))
                .ForMember(x => x.Name,
                    x => x.MapFrom(a => a.Name))
                .ForMember(x => x.Poster,
                    x => x.MapFrom(a => a.Poster))
                .ForMember(x => x.Rating,
                    x => x.MapFrom(a => a.Rating));
        }
    }
}
