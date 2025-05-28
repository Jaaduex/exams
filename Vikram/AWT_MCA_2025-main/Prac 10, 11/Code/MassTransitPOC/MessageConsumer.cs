using MassTransit;
using MassTransit.Caching;

namespace MassTransitPOC
{
    public class MessageConsumer(ILogger<MessageConsumer> logger):IConsumer<CurrentTime>
    {
        public Task Consume(ConsumeContext<CurrentTime> context)
        {
            logger.LogInformation("{consumer} {message}",nameof(MessageConsumer), context.Message.Value.ToString());
            return Task.CompletedTask;
        }
    }
}
