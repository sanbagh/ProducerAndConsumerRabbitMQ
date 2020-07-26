using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("BasicQueue", false, false, false, null);
                    var message = "This is sender";
                    channel.BasicPublish("", "BasicQueue",null, Encoding.UTF8.GetBytes(message));
                    Console.WriteLine("message sent...");
                    Console.ReadLine();
                }
            }
        }
    }
}
