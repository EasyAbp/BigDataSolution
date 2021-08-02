using Volo.Abp.Modularity;

namespace EasyAbp.BigDataSolution.Metadata
{
    [DependsOn(
        typeof(MetadataApplicationModule),
        typeof(MetadataDomainTestModule)
        )]
    public class MetadataApplicationTestModule : AbpModule
    {

    }
}
