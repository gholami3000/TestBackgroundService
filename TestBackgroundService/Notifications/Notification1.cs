using MediatR;

namespace TestBackgroundService.Notifications
{
    public class Notification1: INotification
    {
        public Guid Id { get; set; }
    }
}
