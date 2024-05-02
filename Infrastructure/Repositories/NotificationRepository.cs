using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Notification>> GetUserNotificationsAsync(int userId)
    {
        var result = await _dbContext.Notifications
            .Where(n => n.UserId == userId)
            .ToListAsync();

        return result;
    }

    public async Task<int> GetUserNotificationsCountAsync(int userId)
    {
        var result = await _dbContext.Notifications
            .CountAsync(n => n.UserId == userId);

        return result;
    }
}
