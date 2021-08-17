using System.Threading.Tasks;
using Cassandra;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra
{
    public interface ICassandraClientFactory : ISingletonDependency
    {
        Task<ICassandraClient> CreateAsync();
    }

    public class CassandraClientFactory : ICassandraClientFactory
    {
        private readonly IConnectionStringResolver _connectionStringResolver;

        private const int AddressIndex = 0;
        private const int KeySpaceIndex = 1;

        public CassandraClientFactory(IConnectionStringResolver connectionStringResolver)
        {
            _connectionStringResolver = connectionStringResolver;
        }

        public async Task<ICassandraClient> CreateAsync()
        {
            var connectionStrings = (await _connectionStringResolver.ResolveAsync()).Split(';');

            var cluster = Cluster.Builder()
                .AddContactPoint(connectionStrings[AddressIndex])
                .Build();

            var session = await cluster.ConnectAsync(connectionStrings[KeySpaceIndex]);

            return new CassandraClient(session);
        }
    }
}