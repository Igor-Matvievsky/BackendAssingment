using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.Entities.Base;

namespace DL.IUnitOfWork
{
    public interface IUnitOfWork
    {
        TEntity Add<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        Task AddRange<TEntity>(List<TEntity> entities) where TEntity : class, IBaseEntity;

        Task<List<TEntity>> AddAsync<TEntity>(List<TEntity> entities) where TEntity : class, IBaseEntity;

        void Update<TEntity>(TEntity model) where TEntity : class, IBaseEntity;

        TEntity UpdateWithRsult<TEntity>(TEntity model) where TEntity : class, IBaseEntity;

        void Delete<TEntity>(TEntity model) where TEntity : class, IBaseEntity;

        void DeleteRange<TEntity>(List<TEntity> entity) where TEntity : class, IBaseEntity;

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
