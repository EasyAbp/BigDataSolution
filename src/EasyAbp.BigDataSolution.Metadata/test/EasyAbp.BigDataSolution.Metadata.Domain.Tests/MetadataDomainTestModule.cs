using EasyAbp.BigDataSolution.Metadata.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.BigDataSolution.Metadata
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(MetadataEntityFrameworkCoreTestModule)
        )]
    public class MetadataDomainTestModule : AbpModule
    {
        
    }
}
