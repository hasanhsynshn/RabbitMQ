using Newtonsoft.Json;

namespace RabbitMQPublisher
{
    public class MessageModel
    {
        public string MessageId { get; set; } = "test";
        public string Sender { get; set; } = "hasan hüseyin";
        public string Recipient { get; set; } = "consumer";
        public string Content { get; set; } = "first message";
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
