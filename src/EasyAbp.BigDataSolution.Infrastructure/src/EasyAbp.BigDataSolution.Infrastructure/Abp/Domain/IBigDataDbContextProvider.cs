using System.Threading;
using System.Threading.Tasks;

namespace EasyAbp.BigDataSolution.Infrastructure.Abp.Domain
{
    public interface IBigDataDbContextProvider<TBigDataDbContext> where TBigDataDbContext : IBigDataDbContext
    {
        Task<TBigDataDbContext> GetDbContextAsync(CancellationToken cancellationToken = default);
    }
}