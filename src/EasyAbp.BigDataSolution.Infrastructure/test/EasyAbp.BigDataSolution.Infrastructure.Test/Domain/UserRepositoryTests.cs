using System;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Domain
{
    public class UserRepositoryTests : EasyAbpBigDataInfrastructureTestBase
    {
        public UserRepositoryTests()
        {
            var userRep = GetRequiredService<IRepository<User>>();
        }

        [Fact]
        public void Test()
        {
            Console.WriteLine("Ok");
        }
    }
}