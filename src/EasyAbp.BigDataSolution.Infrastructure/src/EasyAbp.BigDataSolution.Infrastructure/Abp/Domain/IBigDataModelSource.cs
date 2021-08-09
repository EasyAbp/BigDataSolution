namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public interface IBigDataModelSource
    {
        BigDataDbContextModel GetModel(BigDataDbContext dbContext);
    }
}