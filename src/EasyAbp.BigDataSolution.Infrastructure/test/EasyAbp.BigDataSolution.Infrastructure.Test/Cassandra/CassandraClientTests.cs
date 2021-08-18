using Cassandra;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra;
using EasyAbp.BigDataSolution.Infrastructure.Test.Domain;
using Shouldly;
using Xunit;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Cassandra
{
    public class CassandraClientTests : EasyAbpBigDataInfrastructureTestBase
    {
        [Fact]
        public async void ExecuteQueryAsync_Test()
        {
            var clientSession = new CassandraClient(await Cluster.Builder()
                .AddContactPoint("192.168.124.128")
                .Build()
                .ConnectAsync("TenantManagement"));

            var result = await clientSession.ExecuteQueryAsync("SELECT * FROM \"Tenant\"");

            result.ShouldNotBeNull();
        }
    }
}