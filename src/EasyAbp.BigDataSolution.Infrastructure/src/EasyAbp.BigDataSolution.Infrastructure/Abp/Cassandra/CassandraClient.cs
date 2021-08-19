using System.Threading.Tasks;
using Cassandra;
using Cassandra.Data.Linq;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Cassandra
{
    public class CassandraClient : ICassandraClient
    {
        public ISession OriginalSession { get; }

        public CassandraClient(ISession originalSession)
        {
            OriginalSession = originalSession;
        }

        public Task<RowSet> ExecuteQueryAsync(string queryString)
        {
            return OriginalSession.ExecuteAsync(new SimpleStatement(queryString));
        }

        public async Task InsertAsync<TEntity>(TEntity entity)
        {
            var table = new Table<TEntity>(OriginalSession);
            table.Insert(entity);
            await table.ExecuteAsync();
        }
    }

    public interface ICassandraClient
    {
        Task<RowSet> ExecuteQueryAsync(string queryString);

        Task InsertAsync<TEntity>(TEntity entity);
    }
}