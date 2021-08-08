using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain.Repositories
{
    public interface IBigDataRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
    }

    public interface IBigDataRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
    }
}