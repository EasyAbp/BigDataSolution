using System.Threading.Tasks;
using Cassandra;

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
    }

    public interface ICassandraClient
    {
        Task<RowSet> ExecuteQueryAsync(string queryString);
    }
}