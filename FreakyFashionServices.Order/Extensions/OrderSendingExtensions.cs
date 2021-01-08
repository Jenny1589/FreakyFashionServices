using FreakyFashionServices.Order.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace FreakyFashionServices.Order.Extensions
{
    public static class OrderSendingExtensions
    {
        public static void Send(this CustomerOrder order, RabbitMqSettings settings)
        {
            var factory = new ConnectionFactory
            {
                HostName = settings.HostName,
                Port = settings.Port
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
