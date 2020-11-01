using MassTransit;
using masstransit_consumer_api_first.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace masstransit_consumer_api_first.Consumer
{
    public sealed class OrderConsumer : IConsumer<Order>
    {
        private readonly ILogger<OrderConsumer> _logger;

        public OrderConsumer(ILogger<OrderConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Order> context)
        {
            try
            {
                var order = context.Message;

                _logger.LogInformation($"Order received: {order.OrderId}");

            }catch(Exception ex)
            {
                _logger.LogError("Error on try to consume order", ex);
            }

            return Task.CompletedTask;
        }
    }
}
