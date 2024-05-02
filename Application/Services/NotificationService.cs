using Application.Abstractions;
using Application.Dtos.NotificationDtos;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    private readonly IMapper _mapper;

    public NotificationService(
        INotificationRepository notificationRepository,
        IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<List<NotificationPreviewDto>> GetNotificationsAsync(int userId)
    {
        var dbNotifications = await _notificationRepository.GetUserNotificationsAsync(userId);

        var viewNotifications = _mapper.Map<List<NotificationPreviewDto>>(dbNotifications);

        return viewNotifications;
    }

    public async Task<NotificationDto> GetNotificationDetailedAsync(int id)
    {
        var dbNotification = await _notificationRepository.GetByIdAsync(id);

        var viewNotification = _mapper.Map<NotificationDto>(dbNotification);

        return viewNotification;
    }

    public async Task<int> CountNotificationsAsync(int userId)
    {
        int notificationCount = await _notificationRepository.GetUserNotificationsCountAsync(userId);

        return notificationCount;
    }

    public async Task DeleteNotificationAsync(int id)
    {
        await _notificationRepository.DeleteByIdAsync(id);
    }
}
