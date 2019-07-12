namespace MoviesApp.Data.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> 
        where TEntity : class
    {
        IQueryable<TEntity> All();
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
