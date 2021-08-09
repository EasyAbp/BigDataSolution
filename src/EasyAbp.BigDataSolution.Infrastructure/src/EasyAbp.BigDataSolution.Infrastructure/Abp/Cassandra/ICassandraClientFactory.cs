using Volo.Abp.DependencyInjection;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra
{
    public interface ICassandraClientFactory : ISingletonDependency
    {
        ICassandraClient Create();
    }

    public class CassandraClientFactory : ICassandraClientFactory
    {
        public ICassandraClient Create()
        {
            throw new System.NotImplementedException();
        }
    }
}