using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.DependencyInjection
{
    public class BigDataDbContextRegistrationOptions : AbpCommonDbContextRegistrationOptions,
        IBigDataDbContextRegistrationOptionsBuilder
    {
        public BigDataDbContextRegistrationOptions(Type originalDbContextType,
            IServiceCollection services) : base(originalDbContextType,
            services)
        {
        }
    }
}