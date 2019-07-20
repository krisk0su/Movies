namespace MoviesApp.Services.DataServices
{

    using System.Threading.Tasks;
    using Contracts;
    using ViewModels.AnimesEntities;
    using MoviesApp.Data.Contracts;
    using Data.Models.Animes;


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
