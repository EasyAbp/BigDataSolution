using Cassandra;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra;
using Shouldly;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Cassandra
{
    public class CassandraClientTests : EasyAbpBigDataInfrastructureTestBase
    {
        public async void ExecuteQueryAsync_Test()
        {
            var clientSession = new CassandraClient(await Cluster.Builder()
                .AddContactPoint("")
                .Build()
                .ConnectAsync(""));

            var result = await clientSession.ExecuteQueryAsync("SELECT * FROM TestTenant");

            result.ShouldNotBeNull();
        }
    }
}