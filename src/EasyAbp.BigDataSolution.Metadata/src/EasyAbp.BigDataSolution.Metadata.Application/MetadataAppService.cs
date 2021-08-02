using EasyAbp.BigDataSolution.Metadata.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.BigDataSolution.Metadata
{
    public abstract class MetadataAppService : ApplicationService
    {
        protected MetadataAppService()
        {
            LocalizationResource = typeof(MetadataResource);
            ObjectMapperContext = typeof(MetadataApplicationModule);
        }
    }
}
