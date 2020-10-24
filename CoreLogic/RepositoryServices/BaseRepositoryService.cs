using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Entity.Models;

namespace CoreLogic.RepositoryServices
{
    public interface IBaseRepositoryService<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> All { get; }
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        TEntity Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> Update(IEnumerable<TEntity> entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
    }

    public abstract class BaseRepositoryService<TEntity> : IBaseRepositoryService<TEntity> where TEntity : EntityBase
    {
        private ProjectContext _dbContext;
        
        protected BaseRepositoryService(ProjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> All
            => _dbContext.Set<TEntity>();

        public TEntity GetById(Guid id)
            => _dbContext.Find<TEntity>(id);
        
        public async Task<TEntity> GetByIdAsync(Guid id)
            => (await _dbContext.FindAsync<TEntity>(id));
        

        public TEntity Add(TEntity entity)
            => _dbContext.Add(entity).Entity;

        public void Add(IEnumerable<TEntity> entities)
            => _dbContext.AddRange(entities);

        
        public async Task<TEntity> AddAsync(TEntity entity)
            => (await _dbContext.AddAsync(entity)).Entity;
        
        public async Task AddAsync(IEnumerable<TEntity> entities)
            => await _dbContext.AddRangeAsync(entities);
        
        
        public TEntity Update(TEntity entity)
            => _dbContext.Update(entity).Entity;

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entity)
            => _dbContext.Update(entity).Entity;


        public void Delete(Guid id)
            => _dbContext.Remove(GetById(id));
        
        public void Delete(TEntity entity)
            => _dbContext.Remove(entity);
    }
}