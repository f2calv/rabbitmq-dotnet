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
        Console.WriteLine("Waiting 15 seconds for RabbitMQ to fully start...");
        await Task.Delay(15_000);//delay startup
        var factory = new ConnectionFactory() { HostName = "rabbitmq" };
        using (var connection = await factory.CreateConnectionAsync())
        using (var channel = await connection.CreateChannelAsync())
        {
            await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            while (true)
            {
                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
                Console.WriteLine(" [x] Sent {0}", message);
                await Task.Delay(1_000);//delay
            }
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}