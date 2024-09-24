using Leapspark.Bootstrap.Application.Service.MessageQueue;
using Leapspark.Bootstrap.Services.MessageQueue;
using Leapspark.Bootstrap.Services.MessageQueue.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapspark.Bootstrap.Application.Service.Extensions.MessageQueue.Extensions
{
    public static class Extensions
    {
        public static MessageQueueBuilder AddRabbitMq(this MessageQueueBuilder messageQueueBuilder, RabbitMqConfiguration rabbitMqConfiguration)
        {
            messageQueueBuilder.Services.AddSingleton<IMessageQueue>(new RabbitMqService(rabbitMqConfiguration));

            return messageQueueBuilder;
        }
    }
}
