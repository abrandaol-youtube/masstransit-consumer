using MassTransit;
using masstransit_consumer_api_first.Domain;
using System;
using System.Threading.Tasks;

namespace masstransit_consumer_api_first.Consumer
{
    public interface IOrderConsumer : IConsumer<Order>
    {
        event EventHandler<Order> OrderReceived;

        Task Consume(ConsumeContext<Order> context);
    }
}
