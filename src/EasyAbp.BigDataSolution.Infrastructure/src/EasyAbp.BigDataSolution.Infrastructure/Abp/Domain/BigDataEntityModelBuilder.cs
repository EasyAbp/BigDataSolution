using System;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataEntityModelBuilder<TEntity> :
        IBigDataEntityModelBuilder<TEntity>,
        IBigDataEntityModel,
        IBigDataEntityModelBuilder
    {
        public Type EntityType { get; }

        public string TableName { get; set; }

        public BigDataEntityModelBuilder()
        {
            EntityType = typeof(TEntity);
        }
    }
}