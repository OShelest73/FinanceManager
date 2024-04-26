using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WalletRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Wallet>> GetAllUserWalletsAsync(int userId)
    {
        var result = await _dbContext.Wallets.Where(w => w.UserId == userId).ToListAsync();

        return result;
    }
}
