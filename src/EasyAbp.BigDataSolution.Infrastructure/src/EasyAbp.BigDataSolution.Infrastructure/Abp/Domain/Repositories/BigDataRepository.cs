using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain.Repositories
{
    public class BigDataRepository<TBigDataDbContext, TEntity> :
        RepositoryBase<TEntity>,
        IBigDataRepository<TEntity>
        where TBigDataDbContext : IBigDataDbContext
        where TEntity : class, IEntity
    {
        protected IBigDataDbContextProvider<TBigDataDbContext> DbContextProvider { get; }

        public BigDataRepository(IBigDataDbContextProvider<TBigDataDbContext> dbContextProvider)
        {
            DbContextProvider = dbContextProvider;
        }

        public override async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            cancellationToken = GetCancellationToken(cancellationToken);

            var dbContext = await GetDbContextAsync(cancellationToken);
            await dbContext.CassandraClient.InsertAsync(entity);

            return entity;
        }

        public override async Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken = GetCancellationToken(cancellationToken);
            var dbContext = await GetDbContextAsync(cancellationToken);
            await dbContext.CassandraClient.InsertManyAsync(entities);
        }

        public override Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = false,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<long> GetCountAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, bool includeDetails = false,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<TEntity> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public override Task<IQueryable<TEntity>> GetQueryableAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public override Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        protected Task<TBigDataDbContext> GetDbContextAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken = GetCancellationToken(cancellationToken);

            // Multi-tenancy unaware entities should always use the host connection string
            if (!EntityHelper.IsMultiTenant<TEntity>())
            {
                using (CurrentTenant.Change(null))
                {
                    return DbContextProvider.GetDbContextAsync(cancellationToken);
                }
            }

            return DbContextProvider.GetDbContextAsync(cancellationToken);
        }
    }

    public class BigDataRepository<TBigDataDbContext, TEntity, TKey> :
        BigDataRepository<TBigDataDbContext, TEntity>,
        IBigDataRepository<TEntity, TKey>
        where TBigDataDbContext : IBigDataDbContext
        where TEntity : class, IEntity<TKey>
    {
        public BigDataRepository(IBigDataDbContextProvider<TBigDataDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}