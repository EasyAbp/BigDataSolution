using System;
using System.Linq;
using System.Reflection;
using EasyAbp.BigDataSolution.Infrastructure.Abp.DependencyInjection;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.BigDataSolution.Infrastructure.Microsoft.Extensions.DependencyInjection
{
    public static class BigDataDbServiceCollectionExtensions
    {
        public static IServiceCollection AddBigDataDbContext<TBigDataDbContext>(this IServiceCollection services,
            Action<IBigDataDbContextRegistrationOptionsBuilder> optionsBuilder = null) //Created overload instead of default parameter
            where TBigDataDbContext : BigDataDbContext
        {
            var options = new BigDataDbContextRegistrationOptions(typeof(TBigDataDbContext), services);

            var replacedDbContextTypes = typeof(TBigDataDbContext).GetCustomAttributes<ReplaceDbContextAttribute>(true)
                .SelectMany(x => x.ReplacedDbContextTypes).ToList();

            foreach (var dbContextType in replacedDbContextTypes)
            {
                options.ReplaceDbContext(dbContextType);
            }

            optionsBuilder?.Invoke(options);

            foreach (var entry in options.ReplacedDbContextTypes)
            {
                var originalDbContextType = entry.Key;
                var targetDbContextType = entry.Value ?? typeof(TBigDataDbContext);

                services.Replace(
                    ServiceDescriptor.Transient(
                        originalDbContextType,
                        sp => sp.GetRequiredService(targetDbContextType)
                    )
                );

                services.Configure<BigDataDbContextOptions>(opts => { opts.DbContextReplacements[originalDbContextType] = targetDbContextType; });
            }

            new BigDataRepositoryRegistrar(options).AddRepositories();

            return services;
        }
    }
}