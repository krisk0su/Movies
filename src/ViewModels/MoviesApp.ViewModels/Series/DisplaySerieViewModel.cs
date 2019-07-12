namespace MoviesApp.ViewModels.Series
{
    using AutoMapper;
    using Contracts;
    using System;
    using Data.Models.Series;
    using Services.Mapping;

    public class DisplaySerieViewModel:IDisplayable, IMapFrom<Series>, IHaveCustomMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Type { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Series, DisplaySerieViewModel>()
                .ForMember(x => x.Id,
                    x => x.MapFrom(s => s.Id))
                .ForMember(x => x.Name,
                    x => x.MapFrom(s => s.Name))
                .ForMember(x => x.Poster,
                    x => x.MapFrom(s => s.Poster))
                .ForMember(x => x.Rating,
                    x => x.MapFrom(s => s.Rating));
        }
    }
}
