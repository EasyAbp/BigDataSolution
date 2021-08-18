using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataModelBuilder : IBigDataModelBuilder
    {
        private readonly Dictionary<Type, object> _entityModelBuilders;
        private static readonly object Locker = new object();

        public BigDataModelBuilder()
        {
            _entityModelBuilders = new Dictionary<Type, object>();
        }

        public void Entity<TEntity>(Action<IBigDataEntityModelBuilder<TEntity>> buildAction = null) where TEntity : class, IEntity, new()
        {
            var model = (IBigDataEntityModelBuilder<TEntity>)_entityModelBuilders.GetOrAdd(
                typeof(TEntity),
                () => new BigDataEntityModelBuilder<TEntity>());

            buildAction?.Invoke(model);
        }

        public void Entity(Type entityType, Action<IBigDataEntityModelBuilder> buildAction = null)
        {
            var model = (IBigDataEntityModelBuilder)_entityModelBuilders.GetOrAdd(entityType,
                () => Activator.CreateInstance(
                    typeof(IBigDataEntityModelBuilder<>).MakeGenericType(entityType)));

            buildAction?.Invoke(model);
        }

        public IReadOnlyList<IBigDataEntityModel> GetEntities()
        {
            return _entityModelBuilders.Values.Cast<IBigDataEntityModel>().ToImmutableList();
        }

        public BigDataDbContextModel Build(BigDataDbContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}