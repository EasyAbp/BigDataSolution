using System;
using Cassandra;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataEntityModelBuilder<TEntity> :
        IBigDataEntityModelBuilder<TEntity>,
        IBigDataEntityModel,
        IBigDataEntityModelBuilder where TEntity : class, IEntity, new()
    {
        public Type EntityType { get; }

        public string TableName { get; set; }
        UdtMap IBigDataEntityModelBuilder.UdtMap => UdtMap;

        public UdtMap<TEntity> UdtMap { get; }

        public BigDataEntityModelBuilder()
        {
            EntityType = typeof(TEntity);
        }
    }
}