using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Services.DataServices
{
    using System.Collections.Generic;
    using MoviesApp.Data.Contracts;
    using Data.Models.Categories;
    using Contracts;
    using Mapping;
    using ViewModels.Categories;

    public class CategoryService:ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            this._repository = repository;
        }

        public IList<Category> AllCategories()
        {
            var categories = _repository
                .All()
                .OrderBy(x=> x.Name)
                .ToList();

            return categories;
        }

        public IList<SelectListItem> SelectList()
        {
            var categories = this._repository.All().ToList();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var category in categories)
            {
                var item = new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                };
                items.Add(item);
            }

            return items;
        }

        public async Task<int> Create(CreateCategoryViewModel model)
        {
            var category = new Category()
            {
                Name = model.Name
            };

            await this._repository.Add(category);
            await this._repository.SaveChangesAsync();
            return category.Id;
        }

        public async Task<int> CreateCategory(string name)
        {
            
            if (!this.CategoryExists(name))
            {
                var category = new Category()
                {
                    Name = name
                };

                await this._repository.Add(category);
                await this._repository.SaveChangesAsync();
                return category.Id;
            }

            return this._repository.All().Single(x => x.Name == name).Id;

        }

        public DetailsCategoryViewModel Details(string id)
        {
            var vm = this._repository
                .All()
                .To<DetailsCategoryViewModel>()
                .FirstOrDefault(x => x.Id.ToString() == id);
          
            return vm;

        }

        private bool CategoryExists(string name)
        {
            bool doesExist = this._repository.All()
                .Any(x => x.Name == name);

            if (doesExist)
            {
                return true;
            }

            return false;
        }
    }
}
