using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

// Can be read from appsettings or somewhere like etcd
var factory = new ConnectionFactory() { HostName = "localhost" };

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "info", durable: false, exclusive: false, autoDelete: false, arguments: null);
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Incoming message: {0}", message);
    };
    channel.BasicConsume(queue: "info", autoAck: true, consumer: consumer);
}