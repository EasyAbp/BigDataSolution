using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.BigDataSolution.Metadata
{
    [DependsOn(
        typeof(MetadataDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class MetadataApplicationContractsModule : AbpModule
    {

    }
}
