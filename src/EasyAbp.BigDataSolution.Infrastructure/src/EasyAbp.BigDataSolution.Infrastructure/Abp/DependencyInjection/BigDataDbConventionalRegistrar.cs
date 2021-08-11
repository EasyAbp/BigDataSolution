using System;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.DependencyInjection
{
    public class BigDataDbConventionalRegistrar : DefaultConventionalRegistrar
    {
        public override void AddType(IServiceCollection services, Type type)
        {
            if (!typeof(IBigDataDbContext).IsAssignableFrom(type) || type == typeof(BigDataDbContext))
            {
                return;
            }

            var dependencyAttribute = GetDependencyAttributeOrNull(type);
            var lifeTime = GetLifeTimeOrNull(type, dependencyAttribute);

            if (lifeTime == null)
            {
                return;
            }

            services.Add(ServiceDescriptor.Describe(typeof(IBigDataDbContext), type, ServiceLifetime.Transient));
        }
    }
}