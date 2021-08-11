using System;
using System.Collections.Generic;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain;
using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.DependencyInjection
{
    public class BigDataRepositoryRegistrar : RepositoryRegistrarBase<BigDataDbContextRegistrationOptions>
    {
        public BigDataRepositoryRegistrar(BigDataDbContextRegistrationOptions options) : base(options)
        {
        }

        protected override IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            return BigDataDbContextHelper.GetEntityTypes(dbContextType);
        }

        protected override Type GetRepositoryType(Type dbContextType, Type entityType)
        {
            return typeof(BigDataRepository<,>).MakeGenericType(dbContextType, entityType);
        }

        protected override Type GetRepositoryType(Type dbContextType, Type entityType, Type primaryKeyType)
        {
            return typeof(BigDataRepository<,,>).MakeGenericType(dbContextType, entityType, primaryKeyType);
        }
    }
}