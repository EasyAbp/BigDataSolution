using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.BigDataSolution.Metadata.EntityFrameworkCore
{
    [ConnectionStringName(MetadataDbProperties.ConnectionStringName)]
    public interface IMetadataDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}