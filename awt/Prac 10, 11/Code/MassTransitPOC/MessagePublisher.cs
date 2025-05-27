using MassTransit;
using MassTransit.Caching;

namespace MassTransitPOC
{
    public class MessagePublisher(IBus bus):BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await bus.Publish(
                    new CurrentTime
                    {
                        Value = $"Current timestamp published: {DateTime.Now}" 
                    }, stoppingToken) ;
                await Task.Delay(1000,stoppingToken);
            }
        }
    }
}
