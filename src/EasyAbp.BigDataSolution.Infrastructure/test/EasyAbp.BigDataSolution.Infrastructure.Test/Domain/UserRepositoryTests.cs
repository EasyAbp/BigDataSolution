using System;
using System.Threading.Tasks;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Domain
{
    public class UserRepositoryTests : EasyAbpBigDataInfrastructureTestBase
    {
        private readonly IRepository<User> _usersRep;

        public UserRepositoryTests()
        {
            _usersRep = GetRequiredService<IRepository<User>>();
        }

        [Fact]
        public async Task Insert_Test()
        {
            await _usersRep.InsertAsync(new User(Guid.NewGuid())
            {
                UserName = "Admin",
                Password = "Admin".ToMd5()
            });
        }
    }
}