using Domain.Entities;

namespace Domain.Abstractions;

public interface IWalletRepository
{
    Task<List<Wallet>> GetAllUserWalletsAsync(int userId);

    Task<Wallet> GetWalletByIdAsync(int id);

    Task CreateWalletAsync(Wallet wallet);

    Task UpdateWalletAsync(Wallet wallet);

    Task DeleteWalletAsync(Wallet wallet);

    Task SaveAsync();
}
