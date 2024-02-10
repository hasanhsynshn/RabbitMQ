using RabbitMQ.Client;
using RabbitMQPublisher;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare("test_exchange",ExchangeType.Direct,false,false);
    channel.QueueDeclare(queue: "info", durable: false, exclusive: false, autoDelete: false, arguments: null);

    channel.QueueBind("info","test_exchange","info_route");
    // Message content
    string message = new MessageModel().ToString();
    var body = Encoding.UTF8.GetBytes(message);

    
    channel.BasicPublish(exchange: "direct",
                         routingKey: "info", // Routing key
                         basicProperties: null,
                         body: body);
}

