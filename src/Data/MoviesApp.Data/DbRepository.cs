using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data.Contracts;

namespace MoviesApp.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly MoviesAppContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public DbRepository(MoviesAppContext context)
        {
            this._dbContext = context;
            this._dbSet = this._dbContext.Set<TEntity>();
            
        }

        public IQueryable<TEntity> All()
        {
            return this._dbSet;
        }

        public Task Add(TEntity entity)
        {
            return this._dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
             this._dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this._dbContext.SaveChangesAsync();
        }
    }
}
