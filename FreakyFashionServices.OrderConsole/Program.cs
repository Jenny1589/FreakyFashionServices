using FreakyFashionServices.OrderConsole.Data;
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
        private static readonly FreakyFashionOrderDbContext _dbContext = new FreakyFashionOrderDbContext();
        private static bool hasIncomingOrders = false;

        static void Main(string[] args)
        {
            var isRunning = true;
            Console.CursorVisible = false;

            if (!hasIncomingOrders) Console.WriteLine("Waiting for incoming orders...");

            using var connection = CreateRabbitMqConnection();
            using var channel = connection.CreateModel();

            var queueName = "order";
            DeclareMessageQueue(channel, queueName);

            var consumer = InitializeRabbitMqConsumer(channel, queueName);
            consumer.Received += OnRecieved;

            while (isRunning)
            {
                var keyPressed = Console.ReadKey(false).Key;

                switch (keyPressed)
                {
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                    default:
                        isRunning = true;
                        break;
                }
            }            
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

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            if (!hasIncomingOrders)
            {
                Console.Clear();
                hasIncomingOrders = true;

                Console.WriteLine("Orders recieved this session:\n\n");

                Console.WriteLine("Order Id\tCustomer Id");
                Console.WriteLine(new string('-', Console.WindowWidth));
            }

            Console.WriteLine($" {order.OrderId}\t\t{order.CustomerIdentifier}\n");            

            foreach (var orderItem in order.Items)
            {
                Console.WriteLine($"\t{orderItem.Id}\t{orderItem.ProductName}\tQty: {orderItem.Quantity}");
            }

            Console.WriteLine(new string('-', Console.WindowWidth));
        }
    }
}
