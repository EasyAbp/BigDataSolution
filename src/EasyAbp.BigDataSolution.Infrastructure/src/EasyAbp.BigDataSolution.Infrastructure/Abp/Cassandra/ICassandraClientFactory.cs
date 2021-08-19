using System.Threading;
using System.Threading.Tasks;
using Cassandra;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra
{
    public interface ICassandraClientFactory
    {
        Task<ICassandraClient> CreateAsync(BigDataConnectionString connectionString, CancellationToken cancellationToken = default);
    }

    public class CassandraClientFactory : ICassandraClientFactory, ISingletonDependency
    {
        public async Task<ICassandraClient> CreateAsync(BigDataConnectionString connectionString,
            CancellationToken cancellationToken = default)
        {
            var session = await Cluster.Builder()
                .AddContactPoint(connectionString.CassandraAddress)
                .Build()
                .ConnectAsync(connectionString.CassandraKeySpace);

            return new CassandraClient(session);
        }
    }
}