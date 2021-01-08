using FreakyFashionServices.OrderConsole.Data.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace FreakyFashionServices.OrderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var isRunning = true;
            Console.WriteLine("Waiting for orders...");

            using var connection = CreateRabbitMqConnection();
            using var channel = connection.CreateModel();

            var queueName = "order";
            DeclareMessageQueue(channel, queueName);

            var consumer = InitializeRabbitMqConsumer(channel, queueName);
            consumer.Received += OnRecieved;

            Console.ReadKey(false);
        }

        private static IConnection CreateRabbitMqConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 15672
            };

            return factory.CreateConnection();
        }

        private static void DeclareMessageQueue(IModel channel, string queueName)
        {
            channel.QueueDeclare(queue: queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        private static EventingBasicConsumer InitializeRabbitMqConsumer(IModel channel, string queueName)
        {
            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume(queue: queueName,
                autoAck: true,
                consumer: consumer);

            return consumer;
        }

        private static void OnRecieved(object model, BasicDeliverEventArgs ea)
        {
            var encodedOrder = ea.Body.ToArray();
            var serializedOrder = Encoding.UTF8.GetString(encodedOrder);

            var order = JsonConvert.DeserializeObject<Order>(serializedOrder);

            Console.WriteLine($"{order.CustomerIdentifier}");

            //Save incoming order in database.
        }
    }
}
