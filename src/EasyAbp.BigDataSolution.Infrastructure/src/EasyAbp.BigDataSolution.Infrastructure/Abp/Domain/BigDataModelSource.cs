using System;
using System.Collections.Concurrent;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataModelSource : IBigDataModelSource
    {
        protected readonly ConcurrentDictionary<Type, BigDataDbContextModel> ModelCache = new ConcurrentDictionary<Type, BigDataDbContextModel>();

        public BigDataDbContextModel GetModel(BigDataDbContext dbContext)
        {
            return ModelCache.GetOrAdd(
                dbContext.GetType(),
                _ => CreateModel(dbContext));
        }

        protected virtual BigDataDbContextModel CreateModel(BigDataDbContext dbContext)
        {
            var modelBuilder = CreateModelBuilder();
            // Constructing entities from DbContext is not supported.
            BuildModelFromDbContextInstance(modelBuilder, dbContext);
            return modelBuilder.Build(dbContext);
        }

        protected virtual BigDataModelBuilder CreateModelBuilder()
        {
            return new BigDataModelBuilder();
        }

        protected virtual void BuildModelFromDbContextInstance(IBigDataModelBuilder modelBuilder, BigDataDbContext dbContext)
        {
            dbContext.CreateModel(modelBuilder);
        }
    }
}