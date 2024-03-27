using Application.Dtos.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions;

public interface IWalletService
{
    Task<List<WalletViewDto>> GetAllUserWalletsAsync(int userId);

    Task CreateWalletAsync(CreateWalletDto walletDto);

    Task UpdateWalletAsync(UpdateWalletDto walletDto);

    Task DeleteWalletAsync(int id);
}
