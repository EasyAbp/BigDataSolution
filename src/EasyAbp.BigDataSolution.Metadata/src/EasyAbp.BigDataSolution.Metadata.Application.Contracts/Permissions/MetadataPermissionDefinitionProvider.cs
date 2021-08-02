using EasyAbp.BigDataSolution.Metadata.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.BigDataSolution.Metadata.Permissions
{
    public class MetadataPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MetadataPermissions.GroupName, L("Permission:Metadata"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MetadataResource>(name);
        }
    }
}