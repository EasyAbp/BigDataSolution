using Volo.Abp;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public static class BigDataDbContextExtensions
    {
        public static BigDataDbContext ToAbpMongoDbContext(this IBigDataDbContext dbContext)
        {
            var abpMongoDbContext = dbContext as BigDataDbContext;

            if (abpMongoDbContext == null)
            {
                throw new AbpException($"The type {dbContext.GetType().AssemblyQualifiedName} should be convertable to {typeof(BigDataDbContext).AssemblyQualifiedName}!");
            }

            return abpMongoDbContext;
        }
    }
}