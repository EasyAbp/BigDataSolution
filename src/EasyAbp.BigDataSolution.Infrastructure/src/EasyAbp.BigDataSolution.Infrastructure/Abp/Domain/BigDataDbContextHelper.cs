using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Reflection;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public static class BigDataDbContextHelper
    {
        public static IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            return dbContextType.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(property => ReflectionHelper.IsAssignableToGenericType(property.PropertyType, typeof(IBigDataTable<>)))
                .Where(property => typeof(IEntity).IsAssignableFrom(property.PropertyType.GenericTypeArguments[0]))
                .Select(property => property.PropertyType.GenericTypeArguments[0]);
        }
    }
}