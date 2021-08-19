using EasyAbp.BigDataSolution.Infrastructure.Abp.DependencyInjection;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            context.Services.TryAddTransient(
                typeof(IBigDataDbContextProvider<>),
                typeof(BigDataDbContextProvider<>)
            );
        }
    }
}