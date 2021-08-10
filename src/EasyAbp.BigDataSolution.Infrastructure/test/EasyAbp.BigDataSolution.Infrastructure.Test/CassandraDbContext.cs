using EasyAbp.BigDataSolution.Infrastructure.Abp.Domain;
using EasyAbp.BigDataSolution.Infrastructure.Test.Domain;

namespace EasyAbp.BigDataSolution.Infrastructure.Test
{
    public class CassandraDbContext : BigDataDbContext
    {
        public IBigDataTable<User> Users { get; set; }

        protected override void CreateModel(IBigDataModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);
            
            modelBuilder.Entity<User>(u =>
            {
                u.TableName = nameof(User);
            });
        }
    }
}