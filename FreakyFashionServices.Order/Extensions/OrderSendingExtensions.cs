using FreakyFashionServices.Order.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace FreakyFashionServices.Order.Extensions
{
    public static class OrderSendingExtensions
    {
        public static void Send(this CustomerOrder order, string messageHost)
        {
            var factory = new ConnectionFactory
            {
                HostName = messageHost
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "order",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var serializedOrder = JsonConvert.SerializeObject(order);
            var encodedOrder = Encoding.UTF8.GetBytes(serializedOrder);

            channel.BasicPublish(exchange: "",
                routingKey: "order",
                basicProperties: null,
                body: encodedOrder);
        }
    }
}
