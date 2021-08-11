using System.Linq;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain;
using Shouldly;
using Xunit;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Domain
{
    public class BigDataDbContextHelperTests : EasyAbpBigDataInfrastructureTestBase
    {
        [Fact]
        public void GetEntityTypes_Test()
        {
            var types = BigDataDbContextHelper.GetEntityTypes(typeof(CassandraDbContext)).ToList();

            types.ShouldNotBeNull();
            types.Count.ShouldBeGreaterThan(0);
        }
    }
}