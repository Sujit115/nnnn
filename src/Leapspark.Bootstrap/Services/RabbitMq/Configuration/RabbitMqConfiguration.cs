namespace Leapspark.Bootstrap.Services.MessageQueue.Dtos
{
    public class RabbitMqConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
        public string QueueName { get; set; }
    }
}
