using Volo.Abp.Uow;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataDbDatabaseApi : IDatabaseApi
    {
        public IBigDataDbContext DbContext { get; }
        
        public BigDataDbDatabaseApi(IBigDataDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}