using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace TestBackgroundService.Service
{
    public class BackGroundService1: BackgroundService
    {

        private readonly TimeSpan _period = TimeSpan.FromSeconds(10);
        //private readonly UpdateService _updateService;
        private readonly IServiceProvider _service;

        public BackGroundService1(IServiceProvider serviceProvider)
        {
            _service = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_period);

            while (!stoppingToken.IsCancellationRequested &&
                   await timer.WaitForNextTickAsync(stoppingToken))
            {
                using (var scope = _service.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<UpdateService>();
                    service.UpdateStatus();
                }
            }
        }


        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    using PeriodicTimer timer = new PeriodicTimer(_period);

        //    while (!stoppingToken.IsCancellationRequested &&
        //           await timer.WaitForNextTickAsync(stoppingToken))
        //    {
        //        using (var scope = _service.CreateScope())
        //        {
        //            var service = scope.ServiceProvider.GetRequiredService<UpdateService>();
        //            service.UpdateStatus();
        //           // await calStatRepo.InsertCallStat(args);
        //        }
        //    }
        //}




    }
}
