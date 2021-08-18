using System;
using Cassandra;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public interface IBigDataEntityModelBuilder<TEntity> where TEntity : class, IEntity, new()
    {
        Type EntityType { get; }

        string TableName { get; set; }

        UdtMap<TEntity> UdtMap { get; }
    }

    public interface IBigDataEntityModelBuilder
    {
        Type EntityType { get; }

        string TableName { get; set; }

        UdtMap UdtMap { get; }
    }
}