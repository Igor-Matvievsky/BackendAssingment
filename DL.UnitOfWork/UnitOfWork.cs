using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL.DatabaseContext;
using DL.Entities.Base;
using DL.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork.IUnitOfWork
    {
        private readonly ApplicationDbContext _appDbContext;

        public UnitOfWork(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            var dbContext = GetDbContext<TEntity>();
            var dbSet = dbContext.Set<TEntity>();
            entity.CreatedAt = DateTime.UtcNow;
            var result = dbSet.Add(entity);
            return result.Entity;
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            var dbContext = GetDbContext<TEntity>();
            var dbSet = dbContext.Set<TEntity>();
            entity.CreatedAt = DateTime.UtcNow;
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task AddRange<TEntity>(List<TEntity> entities) where TEntity : class, IBaseEntity
        {
            entities.ForEach(x => x.CreatedAt = DateTime.UtcNow);
            var dbContext = GetDbContext<TEntity>();
            var dbSet = dbContext.Set<TEntity>();
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<List<TEntity>> AddAsync<TEntity>(List<TEntity> entities) where TEntity : class, IBaseEntity
        {
            var dbContext = GetDbContext<TEntity>();
            var dbSet = dbContext.Set<TEntity>();

            List<TEntity> result = new List<TEntity>();

            foreach (var entity in entities)
            {
                entity.CreatedAt = DateTime.UtcNow;
                var item = await dbSet.AddAsync(entity);
                result.Add(item.Entity);
            }

            return result;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            var dbContext = GetDbContext<TEntity>();
            var dbEntity = dbContext.Set<TEntity>().Single(t => t.Id == entity.Id);
            entity.UpdatedAt = DateTime.UtcNow;
            dbContext.Entry(dbEntity).CurrentValues.SetValues(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            var dbContext = GetDbContext<TEntity>();
            var dbSet = dbContext.Set<TEntity>();
            dbSet.Remove(entity);
        }

        public void DeleteRange<TEntity>(List<TEntity >entity) where TEntity : class, IBaseEntity
        {
            var dbContext = GetDbContext<TEntity>();
            var dbSet = dbContext.Set<TEntity>();
            dbSet.RemoveRange(entity);
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        protected ApplicationDbContext GetDbContext<TEntity>()
        {
            if (typeof(IBaseEntity).IsAssignableFrom(typeof(TEntity))) return _appDbContext;

            throw new InvalidOperationException("The database context not found for entity " + typeof(TEntity).FullName);
        }

        public TEntity UpdateWithRsult<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
        {
            var dbContext = GetDbContext<TEntity>();
            dbContext.Entry(entity).CurrentValues.SetValues(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            entity.UpdatedAt = DateTime.UtcNow;

            return dbContext.Entry(entity).Entity;
        }
    }
}
