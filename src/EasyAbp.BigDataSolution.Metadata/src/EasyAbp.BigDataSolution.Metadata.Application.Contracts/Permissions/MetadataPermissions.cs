using Volo.Abp.Reflection;

namespace EasyAbp.BigDataSolution.Metadata.Permissions
{
    public class MetadataPermissions
    {
        public const string GroupName = "Metadata";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(MetadataPermissions));
        }
    }
}