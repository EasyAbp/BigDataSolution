using System;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataDbContextProvider<TBigDataDbContext> : IBigDataDbContextProvider<TBigDataDbContext> where TBigDataDbContext : IBigDataDbContext
    {
        public ILogger<BigDataDbContextProvider<TBigDataDbContext>> Logger { get; set; }

        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IConnectionStringResolver _connectionStringResolver;
        private readonly ICancellationTokenProvider _cancellationTokenProvider;
        private readonly ICurrentTenant _currentTenant;
        private readonly ICassandraClientFactory _cassandraClientFactory;
        private readonly BigDataDbContextOptions _options;

        public BigDataDbContextProvider(IOptions<BigDataDbContextOptions> options,
            ICurrentTenant currentTenant,
            IUnitOfWorkManager unitOfWorkManager,
            IConnectionStringResolver connectionStringResolver,
            ICancellationTokenProvider cancellationTokenProvider,
            ICassandraClientFactory cassandraClientFactory)
        {
            _options = options.Value;
            _currentTenant = currentTenant;
            _unitOfWorkManager = unitOfWorkManager;
            _connectionStringResolver = connectionStringResolver;
            _cancellationTokenProvider = cancellationTokenProvider;
            _cassandraClientFactory = cassandraClientFactory;

            Logger = NullLogger<BigDataDbContextProvider<TBigDataDbContext>>.Instance;
        }

        public async Task<TBigDataDbContext> GetDbContextAsync(CancellationToken cancellationToken = default)
        {
            var unitOfWork = _unitOfWorkManager.Current;
            if (unitOfWork == null)
            {
                throw new AbpException(
                    $"A {nameof(IBigDataDbContext)} instance can only be created inside a unit of work!");
            }

            var targetDbContextType = _options.GetReplacedTypeOrSelf(typeof(TBigDataDbContext));
            var connectionString = await ResolveConnectionStringAsync(targetDbContextType);
            var dbContextKey = $"{targetDbContextType.FullName}_{connectionString}";

            var bigDataConnectionString = new BigDataConnectionString(connectionString);
            var databaseName = bigDataConnectionString.CassandraKeySpace;
            if (databaseName.IsNullOrWhiteSpace())
            {
                databaseName = ConnectionStringNameAttribute.GetConnStringName<TBigDataDbContext>();
            }

            var databaseApi = unitOfWork.FindDatabaseApi(dbContextKey);
            if (databaseApi == null)
            {
                databaseApi = new BigDataDbDatabaseApi(
                    await CreateDbContextAsync(
                        unitOfWork,
                        bigDataConnectionString,
                        databaseName,
                        cancellationToken
                    )
                );

                unitOfWork.AddDatabaseApi(dbContextKey, databaseApi);
            }

            return (TBigDataDbContext)((BigDataDbDatabaseApi)databaseApi).DbContext;
        }

        private async Task<string> ResolveConnectionStringAsync(Type dbContextType)
        {
            // Multi-tenancy unaware contexts should always use the host connection string
            if (typeof(TBigDataDbContext).IsDefined(typeof(IgnoreMultiTenancyAttribute), false))
            {
                using (_currentTenant.Change(null))
                {
                    return await _connectionStringResolver.ResolveAsync(dbContextType);
                }
            }

            return await _connectionStringResolver.ResolveAsync(dbContextType);
        }

        private async Task<TBigDataDbContext> CreateDbContextAsync(
            IUnitOfWork unitOfWork,
            BigDataConnectionString connectionString,
            string databaseName,
            CancellationToken cancellationToken = default)
        {
            var client = await _cassandraClientFactory.CreateAsync(connectionString, cancellationToken);

            if (unitOfWork.Options.IsTransactional)
            {
                // Ignore Transactional.
            }

            var dbContext = unitOfWork.ServiceProvider.GetRequiredService<TBigDataDbContext>();
            dbContext.ToAbpMongoDbContext().Initialize(client, null, null);

            return dbContext;
        }
    }
}