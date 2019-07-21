namespace MoviesApp.Services.DataServices
{
    using System.Threading.Tasks;
    using Contracts;
    using ViewModels.AnimesEntities;
    using MoviesApp.Data.Contracts;
    using Data.Models.Animes;
    using System;
    using System.Linq;
    using ViewModels.SeriesEntities;
    using System.Collections.Generic;

    public class AnimesEntitiesService:IAnimesEntitiesService
    {
        private readonly IRepository<AnimeEntity> _animesEntitiesRepository;

        public AnimesEntitiesService(IRepository<AnimeEntity> animesEntitiesRepository)
        {
            this._animesEntitiesRepository = animesEntitiesRepository;
        }
        public async Task<int> Create(CreateAnimesEntityViewModel model)
        {
            var entityName = this.GetName(model);

            var animeEntity = new AnimeEntity()
            {
                Name = entityName,
                Episode =  model.Episode,
                Season = model.Season,
                Poster = model.Poster,
                Link1 = model.Link1,
                Link2 = model.Link2,
                AnimeId = model.AnimeId
            };

            await this._animesEntitiesRepository.Add(animeEntity);
            await this._animesEntitiesRepository.SaveChangesAsync();
            return animeEntity.Id;
        }

        public SeasonTableViewModel GetTable(Guid id)
        {
            var result = this._animesEntitiesRepository.All()
                .Where(x => x.AnimeId == id)
                .GroupBy(x => x.Season)
                .Select(x => x.Key)
                .ToList();

            var viewModel = new SeasonTableViewModel(id, result);
            return viewModel;
        }
        public SeasonEntitiesViewModel GetSeasonEntities(CreateSeasonViewModel model)
        {
            var entities = this._animesEntitiesRepository.All()
                .Where(x => x.AnimeId == model.Id
                            && x.Season == model.Season)
                .OrderBy(x => x.Season)
                .ToList();

            var tempCollection = new List<SeasonEntityViewModel>();

            foreach (var entity in entities)
            {
                var temp = new SeasonEntityViewModel(entity.Id,
                    entity.Season,
                    entity.Episode);

                tempCollection.Add(temp);
            }

            var viewModel = new SeasonEntitiesViewModel(tempCollection);

            return viewModel;
        }

        private string GetName(CreateAnimesEntityViewModel model)
        {
            
            var episode = model.Episode < 10 ? "0" + model.Episode 
                : model.Episode.ToString();
            var season = model.Season < 10 ? "0" + model.Season 
                : model.Season.ToString();

            return $"{model.Name} - S_{season} - Ep_{episode}";
        }


    }
}
