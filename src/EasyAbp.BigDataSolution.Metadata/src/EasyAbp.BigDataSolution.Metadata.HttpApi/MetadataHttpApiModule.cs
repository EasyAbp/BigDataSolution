using Localization.Resources.AbpUi;
using EasyAbp.BigDataSolution.Metadata.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.BigDataSolution.Metadata
{
    [DependsOn(
        typeof(MetadataApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class MetadataHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MetadataHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MetadataResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
