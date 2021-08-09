using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class EasyAbpBigDataModule : AbpModule
    {
        
    }
}