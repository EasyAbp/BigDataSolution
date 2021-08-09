using System;
using System.Collections.Generic;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataModelBuilder : IBigDataModelBuilder
    {
        public void Entity<TEntity>(Action<IBigDataEntityModelBuilder<TEntity>> buildAction = null)
        {
            throw new NotImplementedException();
        }

        public void Entity(Type entityType, Action<IBigDataEntityModelBuilder> buildAction = null)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<IBigDataEntityModel> GetEntities()
        {
            throw new NotImplementedException();
        }

        public BigDataDbContextModel Build(BigDataDbContext dbContext)
        {
            throw new NotImplementedException();
            return new BigDataDbContextModel(null);
        }
    }
}