using Volo.Abp;
using Volo.Abp.Testing;

namespace EasyAbp.BigDataSolution.Infrastructure.Test
{
    public class EasyAbpBigDataInfrastructureTestBase : AbpIntegratedTest<EasyAbpBigDataTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}