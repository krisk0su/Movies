namespace MoviesApp.Services.DataServices
{
    using MoviesApp.Data.Contracts;
    using Data.Models.Actors;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts;

    public class ActorsService:IActorsService
    {
        private IRepository<Actor> _repository;

        public ActorsService(IRepository<Actor> repo)
        {
            this._repository = repo;
        }
        public async Task<int> Create(string name)
        {
            bool doesExists = this.ActorExists(name);

            if (!doesExists)
            {
                var actor = new Actor() {Name = name};
                await this._repository.Add(actor);

                return actor.Id;
            }

            return this._repository.All()
                .Single(x => x.Name == name).Id;
        }


        private bool ActorExists(string name)
        {
            bool doesExist = this._repository
                .All()
                .Any(x => x.Name == name);

            if (!doesExist)
            {
                return false;
            }

            return true;
        }
    }
}
