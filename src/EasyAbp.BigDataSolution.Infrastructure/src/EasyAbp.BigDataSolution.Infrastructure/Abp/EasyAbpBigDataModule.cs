using EasyAbp.BigDataSolution.Infrastructure.Abp.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class EasyAbpBigDataModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddConventionalRegistrar(new BigDataDbConventionalRegistrar());
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}