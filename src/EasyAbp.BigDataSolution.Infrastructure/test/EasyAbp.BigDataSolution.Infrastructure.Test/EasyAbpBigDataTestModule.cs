using EasyAbp.BigDataSolution.Infrastructure.Abp;
using EasyAbp.BigDataSolution.Infrastructure.Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace EasyAbp.BigDataSolution.Infrastructure.Test
{
    [DependsOn(typeof(AbpTestBaseModule),
        typeof(EasyAbpBigDataModule),
        typeof(AbpAutofacModule))]
    public class EasyAbpBigDataTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddBigDataDbContext<CassandraDbContext>(op => { op.AddDefaultRepositories(); });
        }
    }
}