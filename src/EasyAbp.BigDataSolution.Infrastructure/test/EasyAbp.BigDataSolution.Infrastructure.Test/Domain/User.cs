using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Domain
{
    public class User : FullAuditedAggregateRoot<Guid>
    {
        public int TenantId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}