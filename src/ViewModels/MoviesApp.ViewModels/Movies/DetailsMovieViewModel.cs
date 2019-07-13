using MoviesApp.Common;

namespace MoviesApp.ViewModels.Movies
{
    using AutoMapper;
    using MoviesApp.Data.Models.Movies;
    using Services.Mapping;
    using System.Collections.Generic;
    using MoviesApp.Data.Models.Categories;
    using System;
    using Contracts;
    using System.Linq;

    public class DetailsMovieViewModel:IBaseEntity, IMapFrom<Movie>, IHaveCustomMapping
    {
        public DetailsMovieViewModel()
        {
            this.Actors = new List<string>();
            this.Categories = new List<Category>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public double Rating { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }

        public string Trailer { get; set; }
        public DateTime CreatedOn { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<string> Actors { get; set; }

        public string DisplayCategories()
        {
            var result = string.Join(" ,", this.Categories.Select(x => x.Name).ToList());

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
        #region Mapping
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, DetailsMovieViewModel>()
                .ForMember(x => x.Id,
                    x => x.MapFrom(m => m.Id))
                .ForMember(x => x.Name,
                    x => x.MapFrom(m => m.Name))
                .ForMember(x => x.Description,
                    x => x.MapFrom(m => m.Description))
                .ForMember(x => x.Link,
                    x => x.MapFrom(m => m.Link))
                .ForMember(x => x.Poster,
                    x => x.MapFrom(m => m.Poster))
                .ForMember(x => x.Trailer,
                    x => x.MapFrom(m => m.Trailer))
                .ForMember(x => x.CreatedOn,
                    x => x.MapFrom(m => m.CreatedOn))
                .ForMember(x => x.ReleaseDate,
                    x => x.MapFrom(m => m.ReleaseDate))
                .ForMember(x => x.Rating,
                    x => x.MapFrom(m => m.Rating));

        }
        #endregion

     
    }
}
