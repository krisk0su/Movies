namespace MoviesApp.Services.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts;
    using Data.Models;
    using MoviesApp.Data.Contracts;
    using System.Linq;

    public class MoviesActorsService:IMoviesActorsService
    {
        private readonly IRepository<MoviesActors> _repository;
        private readonly IActorsService _actorsService;

        public MoviesActorsService(IRepository<MoviesActors> repo,
            IActorsService actorsService)
        {
            this._repository = repo;
            this._actorsService = actorsService;
        }

        public async Task Create(Guid movieId, IEnumerable<string> actorsName)
        {
            foreach (var actName in actorsName)
            {
                var moviesActors = new MoviesActors()
                {
                    MovieId = movieId,
                    ActorId = await this._actorsService.Create(actName)
                };

                await this._repository.Add(moviesActors);
            }

        }

        public IEnumerable<string> Actors(Guid id)
        {
            var actors = this._repository.All()
                .Where(x => x.MovieId == id)
                .Select(x => x.Actor.Name)
                .ToList();

            return actors;
        }
    }
}
