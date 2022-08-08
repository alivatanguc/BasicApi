
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQProductConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";
            var connection = factory.CreateConnection();


            using
                var channel = connection.CreateModel();
            channel.QueueDeclare("order", exclusive: false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Order message received: {message}");
            };
            channel.BasicConsume(queue: "order", autoAck: true, consumer: consumer);
            Console.ReadKey();


        }
    }
}

