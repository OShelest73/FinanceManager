using Application.Dtos.NotificationDtos;

namespace Application.Abstractions;

public interface INotificationService
{
    Task<List<NotificationPreviewDto>> GetNotificationsAsync(int userId);

    Task<NotificationDto> GetNotificationDetailedAsync(int id);

    Task<int> CountNotificationsAsync(int userId);

    Task DeleteNotificationAsync(int id);
}
