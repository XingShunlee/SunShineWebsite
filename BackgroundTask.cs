using ehaikerv202010.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ehaikerv202010
{
    public class CounterService : BackgroundService
    {
        IServiceProvider _IServiceProvider;
        public CounterService(IServiceProvider ServiceProvider)
        {
            _IServiceProvider = ServiceProvider;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Timer timer = new Timer(doWorker, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
            return Task.CompletedTask;
        }
        private void doWorker(object state)
        {
            var stragescounter = _IServiceProvider.GetRequiredService<IWebCountInterface>();
            if (stragescounter != null)
            {
                stragescounter.timer();
            }
            var notecounter = _IServiceProvider.GetRequiredService<INoteCountInterface>();
            if (notecounter != null)
            {
                notecounter.timer();
            }
        }
    }
}
