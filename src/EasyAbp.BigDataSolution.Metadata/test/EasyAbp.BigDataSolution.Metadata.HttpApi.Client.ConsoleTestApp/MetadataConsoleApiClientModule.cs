using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.BigDataSolution.Metadata
{
    [DependsOn(
        typeof(MetadataHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MetadataConsoleApiClientModule : AbpModule
    {
        
    }
}
