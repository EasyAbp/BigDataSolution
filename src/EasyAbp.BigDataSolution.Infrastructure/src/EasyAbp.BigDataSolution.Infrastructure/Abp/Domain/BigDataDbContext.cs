using System.Collections.Generic;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra;
using EasyAbp.BigDataSolution.Infrastructure.Abp.ElasticSearch;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Kafka;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public abstract class BigDataDbContext : IBigDataDbContext, ITransientDependency
    {
        public ICassandraClient CassandraClient { get; private set; }

        public IBigDataModelSource ModelSource { get; set; }

        public virtual void Initialize(ICassandraClient cassandraClient,
            IKafkaClientFactory kafkaClientFactory,
            IElasticSearchClient elasticSearchClient)
        {
        }

        protected internal virtual void CreateModel(IBigDataModelBuilder modelBuilder)
        {
        }

        protected virtual IBigDataEntityModel GetEntityModel<TEntity>()
        {
            var model = ModelSource.GetModel(this).Entities.GetOrDefault(typeof(TEntity));

            if (model == null)
            {
                throw new AbpException("Could not find a model for given entity type: " + typeof(TEntity).AssemblyQualifiedName);
            }

            return model;
        }
    }
}