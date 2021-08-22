using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Bogus;
using Cassandra.Mapping;
using Volo.Abp.Domain.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Domain
{
    public class UserRepositoryTests : EasyAbpBigDataInfrastructureTestBase
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IRepository<User> _usersRep;

        public UserRepositoryTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _usersRep = GetRequiredService<IRepository<User>>();
        }

        [Fact]
        public async Task InsertAsync_Test()
        {
            await _usersRep.InsertAsync(new User(Guid.NewGuid())
            {
                UserName = "Admin",
                Password = "Admin".ToMd5()
            });
        }

        [Fact]
        public async Task InsertManyAsync_Test()
        {
            InitializeMapper();
            var users = new Faker<User>()
                .RuleFor(f => f.Id, x => x.Random.Uuid())
                .RuleFor(f => f.UserName, x => x.Internet.UserName())
                .RuleFor(f => f.Password, x => x.Internet.Password())
                .Generate(500);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await _usersRep.InsertManyAsync(users);
            stopWatch.Stop();
            _testOutputHelper.WriteLine(stopWatch.ElapsedMilliseconds.ToString());
            stopWatch.Reset();
            stopWatch.Start();
            await _usersRep.InsertManyAsync(users);
            stopWatch.Stop();
            _testOutputHelper.WriteLine(stopWatch.ElapsedMilliseconds.ToString());
        }

        private void InitializeMapper()
        {
            MappingConfiguration.Global.Define(new Map<User>()
                .PartitionKey(x => x.Id)
                .Column(x => x.UserName, c => c.WithName("name")));
        }
    }
}