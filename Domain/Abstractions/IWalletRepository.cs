using Domain.Entities;

namespace Domain.Abstractions;

public interface IWalletRepository : IBaseRepository<Wallet>
{
    Task<List<Wallet>> GetAllUserWalletsAsync(int userId);
}
