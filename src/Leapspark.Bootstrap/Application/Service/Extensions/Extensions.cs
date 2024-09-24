using Leapspark.Bootstrap.Application.Service.MessageQueue;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapspark.Bootstrap.Application.Service.Extensions
{
    public static class Extensions
    {
        public static MessageQueueBuilder AddMessageQueue(this IServiceCollection serviceCollection)
        {
            return new MessageQueueBuilder(serviceCollection);
        }

    }
}
