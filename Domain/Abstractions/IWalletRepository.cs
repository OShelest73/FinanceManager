using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
