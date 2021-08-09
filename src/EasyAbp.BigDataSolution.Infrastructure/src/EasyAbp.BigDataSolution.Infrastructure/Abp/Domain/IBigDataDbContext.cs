using EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public interface IBigDataDbContext
    {
        ICassandraClient CassandraClient { get; }
    }
}