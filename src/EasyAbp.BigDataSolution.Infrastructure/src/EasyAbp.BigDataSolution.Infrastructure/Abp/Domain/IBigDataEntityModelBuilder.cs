using System;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public interface IBigDataEntityModelBuilder<TEntity>
    {
        Type EntityType { get; }

        string TableName { get; set; }
    }

    public interface IBigDataEntityModelBuilder
    {
        Type EntityType { get; }

        string TableName { get; set; }
    }
}