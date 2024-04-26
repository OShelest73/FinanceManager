using Application.Dtos.WalletDtos;

namespace Application.Abstractions;

public interface IWalletService
{
    Task<WalletViewDto> GetWalletDetailedAsync(int walletId);

    Task<List<WalletViewDto>> GetUserWalletsAsync(int userId);

    Task<List<SelectWalletDto>> GetWalletsToSelectAsync(int userId);

    Task CreateWalletAsync(CreateWalletDto walletDto);

    Task UpdateWalletAsync(UpdateWalletDto walletDto);

    Task DeleteWalletAsync(int id);
}
