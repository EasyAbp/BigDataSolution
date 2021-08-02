using EasyAbp.BigDataSolution.Metadata.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.BigDataSolution.Metadata
{
    public abstract class MetadataController : AbpController
    {
        protected MetadataController()
        {
            LocalizationResource = typeof(MetadataResource);
        }
    }
}
