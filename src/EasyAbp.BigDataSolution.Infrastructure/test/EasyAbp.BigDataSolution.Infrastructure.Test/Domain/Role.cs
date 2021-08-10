using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Domain
{
    public class Role : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}