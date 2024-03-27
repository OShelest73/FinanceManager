using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WalletRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Wallet>> GetAllUserWalletsAsync(int userId)
    {
        var result = await _dbContext.Wallets.Where(w => w.UserId == userId).ToListAsync();

        return result;
    }

    public async Task<Wallet> GetWalletByIdAsync(int id)
    {
        var result = await _dbContext.Wallets.FirstOrDefaultAsync(w => w.Id == id);

        return result;
    }

    public async Task CreateWalletAsync(Wallet wallet)
    {
        _dbContext.Wallets.Add(wallet);

        await SaveAsync();
    }

    public async Task UpdateWalletAsync(Wallet wallet)
    {
        _dbContext.Wallets.Update(wallet);

        await SaveAsync();
    }

    public async Task DeleteWalletAsync(Wallet wallet)
    {
        _dbContext.Wallets.Remove(wallet);

        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
