using System;
using System.Collections.Generic;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public class BigDataDbContextModel
    {
        public IReadOnlyDictionary<Type, IBigDataEntityModel> Entities { get; }

        public BigDataDbContextModel(IReadOnlyDictionary<Type, IBigDataEntityModel> entities)
        {
            Entities = entities;
        }
    }
}