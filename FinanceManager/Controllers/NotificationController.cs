using Application.Abstractions;
using Application.Dtos.NotificationDtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<List<NotificationPreviewDto>> GetUserNotifications(int userId)
    {
        var notifications = await _notificationService.GetNotificationsAsync(userId);

        return notifications;
    }

    [HttpGet("detailed")]
    public async Task<NotificationDto> GetNotificationDetailed(int id)
    {
        var notification = await _notificationService.GetNotificationDetailedAsync(id);

        return notification;
    }

    [HttpGet("count")]
    public async Task<int> GetNotificationCount(int userId)
    {
        var result = await _notificationService.CountNotificationsAsync(userId);

        return result;
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteNotification(int id)
    {
        await _notificationService.DeleteNotificationAsync(id);

        return Ok();
    }
}
