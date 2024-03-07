using MediatR;
using TestBackgroundService.Models;
using TestBackgroundService.Notifications;

namespace TestBackgroundService.Service
{
    public class RequestService
    {
        private readonly MyAppContext _context;
        private readonly IServiceProvider _serviceProvider;
        private IMediator _mediator;

        public RequestService(MyAppContext context, IServiceProvider serviceProvider, IMediator mediator)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            this._mediator = mediator;
        }

        public void Add()
        {
            var id = Guid.NewGuid();
            _context.Request.Add(new Request
            {
                Id = id,
                Name = "Test" + DateTime.Now.Ticks.ToString(),
                IsActive = false,
            });
            _context.SaveChanges();
            var msg = new Notification1
            {
                Id=id
            };
             _mediator.Publish(msg);

        }

    }
}
