using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Domain
{
    public class User : FullAuditedAggregateRoot<Guid>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public User()
        {
        }

        public User(Guid id)
        {
            Id = id;
        }
    }
}