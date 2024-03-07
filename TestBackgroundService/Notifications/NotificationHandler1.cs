using MediatR;
using TestBackgroundService.Service;

namespace TestBackgroundService.Notifications
{
    public class NotificationHandler1 : INotificationHandler<Notification1>
    {
        private readonly IServiceScopeFactory _service;

        public NotificationHandler1(IServiceScopeFactory service)
        {
            _service = service;
        }

        public Task Handle(Notification1 notification, CancellationToken cancellationToken)
        {
            Task.Run(() =>
            {
                Thread.Sleep(10000);
                using (var scope = _service.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<UpdateService>();
                    service.UpdateStatus1(notification.Id);
                }

            });
           
            return Task.CompletedTask;
        }
    }
}
