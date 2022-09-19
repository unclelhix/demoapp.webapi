using Microsoft.EntityFrameworkCore.Storage;

namespace DemoApplication.WebAPI.Shared.Contracts
{
    public interface IDbContext
    {
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
