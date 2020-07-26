using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    class Receiver
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicQueue", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, e) => {
                    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
                };
                channel.BasicConsume("BasicQueue", true, consumer);
                Console.ReadLine();
            }
        }
    }
}
