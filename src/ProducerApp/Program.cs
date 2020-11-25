using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;
//https://github.com/rabbitmq/rabbitmq-tutorials/blob/master/dotnet/Send/Send.cs
class Program
{
    static async Task Main()
    {
        Console.Title = AppDomain.CurrentDomain.FriendlyName;
        Console.WriteLine("Waiting for RabbitMQ to fully start...");
        await Task.Delay(5_000);//delay startup
        var factory = new ConnectionFactory() { HostName = "rabbitmq" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            while (true)
            {
                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
                await Task.Delay(1_000);//delay
            }
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}