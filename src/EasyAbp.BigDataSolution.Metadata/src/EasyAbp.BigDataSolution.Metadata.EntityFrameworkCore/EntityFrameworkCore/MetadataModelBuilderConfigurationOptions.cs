using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.BigDataSolution.Metadata.EntityFrameworkCore
{
    public class MetadataModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MetadataModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}