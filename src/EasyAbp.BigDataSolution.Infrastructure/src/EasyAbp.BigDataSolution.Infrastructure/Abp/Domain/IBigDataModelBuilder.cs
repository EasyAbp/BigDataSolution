using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public interface IBigDataModelBuilder
    {
        void Entity<TEntity>(Action<IBigDataEntityModelBuilder<TEntity>> buildAction = null);

        void Entity([NotNull] Type entityType, Action<IBigDataEntityModelBuilder> buildAction = null);

        IReadOnlyList<IBigDataEntityModel> GetEntities();
    }
}