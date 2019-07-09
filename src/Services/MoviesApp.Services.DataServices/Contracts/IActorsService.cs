namespace MoviesApp.Services.DataServices.Contracts
{
    using System.Threading.Tasks;


    public interface IActorsService
    {
        Task<int> Create(string name);
    }
}
