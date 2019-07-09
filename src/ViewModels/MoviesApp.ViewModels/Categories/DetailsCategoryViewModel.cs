using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesApp.Data.Models;
using MoviesApp.Data.Models.Categories;
using MoviesApp.Data.Models.Movies;
using MoviesApp.Services.Mapping;
using System.Linq;
namespace MoviesApp.ViewModels.Categories
{
    public class DetailsCategoryViewModel:IMapTo<Category>,IHaveCustomMapping
    {
        public DetailsCategoryViewModel()
        {
            this.MoviesCategories = new HashSet<MoviesCategories>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public HashSet<MoviesCategories> MoviesCategories { get; set; }

        //public IEnumerable<SelectListItem> Items
        //{
        //    get { return this.Magic(); }
        //}

       
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, DetailsCategoryViewModel>()
                .ForMember(x => x.Id,
                    x => x.MapFrom(c => c.Id))
                .ForMember(x => x.Name,
                    x => x.MapFrom(c => c.Name))
                .ForMember(x => x.MoviesCategories,
                    x => x.MapFrom(m => m.MoviesCategories));
        }
    }
}
