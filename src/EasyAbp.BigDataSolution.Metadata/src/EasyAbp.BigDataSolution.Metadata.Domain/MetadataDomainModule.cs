using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.BigDataSolution.Metadata
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(MetadataDomainSharedModule)
    )]
    public class MetadataDomainModule : AbpModule
    {

    }
}
