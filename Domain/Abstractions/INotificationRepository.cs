using Domain.Entities;

namespace Domain.Abstractions;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<List<Notification>> GetUserNotificationsAsync(int userId);

    Task<int> GetUserNotificationsCountAsync(int userId);
}
