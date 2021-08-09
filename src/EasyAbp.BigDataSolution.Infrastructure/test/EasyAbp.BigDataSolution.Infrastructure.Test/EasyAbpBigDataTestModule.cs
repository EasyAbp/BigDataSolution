using Volo.Abp;
using Volo.Abp.Modularity;

namespace EasyAbp.BigDataSolution.Infrastructure.Test
{
    [DependsOn(typeof(AbpTestBaseModule))]
    public class EasyAbpBigDataTestModule : AbpModule
    {
    }
}