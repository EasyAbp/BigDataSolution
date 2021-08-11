using System;
using System.Collections.Generic;
using Volo.Abp;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataDbContextOptions
    {
        internal Dictionary<Type, Type> DbContextReplacements { get; }

        public BigDataDbContextOptions()
        {
            DbContextReplacements = new Dictionary<Type, Type>();
        }
        
        internal Type GetReplacedTypeOrSelf(Type dbContextType)
        {
            var replacementType = dbContextType;
            while (true)
            {
                if (DbContextReplacements.TryGetValue(replacementType, out var foundType))
                {
                    if (foundType == dbContextType)
                    {
                        throw new AbpException(
                            "Circular DbContext replacement found for " +
                            dbContextType.AssemblyQualifiedName
                        );
                    }

                    replacementType = foundType;
                }
                else
                {
                    return replacementType;
                }
            }
        }
    }
}