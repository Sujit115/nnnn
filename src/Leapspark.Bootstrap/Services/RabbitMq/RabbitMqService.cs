using Leapspark.Bootstrap.Dtos;
using Leapspark.Bootstrap.Services.MessageQueue.Dtos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapspark.Bootstrap.Services.MessageQueue
{

    public class RabbitMqService: IMessageQueue
    {
        IModel channel;
        EventingBasicConsumer consumer;
        private readonly RabbitMqConfiguration messageQueueConfiguration;

        public RabbitMqService(RabbitMqConfiguration messageQueueConfiguration)
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri($"amqps://{messageQueueConfiguration.Username}:{messageQueueConfiguration.Password}@octopus.rmq3.cloudamqp.com/uhwkpiid");
            factory.ClientProvidedName = "leapspark";

            IConnection cnn = factory.CreateConnection();

            channel = cnn.CreateModel();

            channel.BasicQos(0, 1, false);

            string exchangeName = messageQueueConfiguration.ExchangeName;
            string routingKey = messageQueueConfiguration.RoutingKey;
            string queueName = messageQueueConfiguration.QueueName;

            channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey);

            consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume(queueName, true, consumer);
            this.messageQueueConfiguration = messageQueueConfiguration;
        }

        public void OnReceived<T>(Action<EventDto<T>> action) where T : class
        {
            consumer.Received += (sender, args) =>
            {
                var content = args.Body.ToArray();

                var message = System.Text.Json.JsonSerializer.Deserialize<EventDto<T>>(content);

                action(message);
            };
        }

        public void Send<T>(EventDto<T> eventDto) where T : class
        {

            var message = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(eventDto));

            string exchangeName = messageQueueConfiguration.ExchangeName;
            string routingKey = messageQueueConfiguration.RoutingKey;
            string queueName = messageQueueConfiguration.QueueName;

            channel.BasicPublish(exchangeName, routingKey, null, message);
        }
    }
}