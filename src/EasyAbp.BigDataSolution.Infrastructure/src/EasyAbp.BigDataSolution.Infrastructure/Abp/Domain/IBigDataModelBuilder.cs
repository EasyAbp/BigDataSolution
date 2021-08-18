using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public interface IBigDataModelBuilder
    {
        void Entity<TEntity>(Action<IBigDataEntityModelBuilder<TEntity>> buildAction = null) where TEntity : class, IEntity, new();

        void Entity([NotNull] Type entityType, Action<IBigDataEntityModelBuilder> buildAction = null);

        IReadOnlyList<IBigDataEntityModel> GetEntities();
    }
}