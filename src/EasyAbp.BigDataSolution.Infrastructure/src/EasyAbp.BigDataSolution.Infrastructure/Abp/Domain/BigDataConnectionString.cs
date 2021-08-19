namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataConnectionString
    {
        public string CassandraKeySpace { get; }

        public string CassandraAddress { get; }

        public BigDataConnectionString(string connectionString)
        {
            var connectionStrings = connectionString.Split('|');

            var cassandraConnectionString = connectionStrings[0].Split(';');
            CassandraAddress = cassandraConnectionString[0];
            CassandraKeySpace = cassandraConnectionString[1];
        }
    }
}