namespace MoviesApp.Services.DataServices
{
    using Contracts;
    using System;
    using System.Threading.Tasks;
    using ViewModels.Animes;
    using MoviesApp.Data.Contracts;
    using Data.Models.Animes;
    using System.Linq;
    using System.Collections.Generic;
    using Mapping;
    using MoviesApp.ViewModels.Contracts;
    

    public class AnimesService : IAnimesService
    {
        private readonly IRepository<Anime> _repository;

        public AnimesService(IRepository<Anime> animesRepo)
        {
            this._repository = animesRepo;
        }

        public async Task<Guid> Create(CreateAnimeViewModel model)
        {
            var anime = new Anime()
            {
                Name = model.Name,
                Description = model.Description,
                Poster = model.Poster,
                Rating = model.Rating,
                ReleaseDate = model.ReleaseDate
            };

            await this._repository.Add(anime);
            await this._repository.SaveChangesAsync();

            return anime.Id;
        }

        public DetailsAnimeViewModel GetAnimeDetails(Guid id)
        {
            var anime = this._repository.All()
                .Single(x => x.Id == id);

            var viewModel = new DetailsAnimeViewModel()
            {
                Id = anime.Id,
                Name = anime.Name,
                Description = anime.Description,
                Poster = anime.Poster,
                Rating = anime.Rating,
                ReleaseDate = anime.ReleaseDate
            };

            return viewModel;

        }

        public IEnumerable<IDisplayable> GetAllAnimes()
        {
            return this._repository
                .All()
                .To<DisplayAnimeViewModel>()
                .OrderBy(x=> x.Rating)
                .ToList();
        }
    }
}
