namespace Domain.Entities;

public class Notification
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string NotificationText { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}
