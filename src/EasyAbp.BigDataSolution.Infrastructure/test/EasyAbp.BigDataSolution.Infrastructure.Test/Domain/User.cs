using System;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.BigDataSolution.Infrastructure.Test.Domain
{
    public class User : Entity<Guid>, IAggregateRoot
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