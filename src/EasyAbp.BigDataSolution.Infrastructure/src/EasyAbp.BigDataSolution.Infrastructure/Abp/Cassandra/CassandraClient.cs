using System.Collections.Generic;
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
            await table.Insert(entity).ExecuteAsync();
        }

        public async Task InsertManyAsync<TEntity>(IEnumerable<TEntity> entities)
        {
            var table = new Table<TEntity>(OriginalSession);
            var batchInsert = table.GetSession().CreateBatch();

            foreach (var entity in entities)
            {
                batchInsert.Append(table.Insert(entity));
            }

            await batchInsert.ExecuteAsync("default");
        }
    }

    public interface ICassandraClient
    {
        Task<RowSet> ExecuteQueryAsync(string queryString);

        Task InsertAsync<TEntity>(TEntity entity);

        Task InsertManyAsync<TEntity>(IEnumerable<TEntity> entities);
    }
}