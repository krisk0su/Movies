namespace MoviesApp.Services.DataServices.Contracts
{
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;


    public interface IMoviesActorsService
    {
        Task Create(Guid movieId, IEnumerable<string> actors);

        IEnumerable<string> Actors(Guid id);
    }
}
