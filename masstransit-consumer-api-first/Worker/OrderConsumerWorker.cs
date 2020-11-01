using masstransit_consumer_api_first.Consumer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace masstransit_consumer_api_first.Worker
{
    public class OrderConsumerWorker : IHostedService
    {
        public ILogger<OrderConsumerWorker> _logger;
        private readonly IOrderConsumer _orderConsumer;

        public OrderConsumerWorker(ILogger<OrderConsumerWorker> logger, IOrderConsumer orderConsumer)
        {
            _logger = logger;
            _orderConsumer = orderConsumer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("A aplicação iniciou");

            _orderConsumer.OrderReceived += _orderConsumer_OrderReceived;

            return Task.CompletedTask;
        }

        private void _orderConsumer_OrderReceived(object sender, Domain.Order order)
        {
            _logger.LogInformation($"OrderId: {order.OrderId}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("A aplicação finalizou");

            return Task.CompletedTask;
        }
    }
}
