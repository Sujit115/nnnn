using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapspark.Bootstrap.Application.Service.MessageQueue
{
    public class MessageQueueBuilder
    {
        public readonly IServiceCollection Services;
        public MessageQueueBuilder(IServiceCollection services)
        {
            this.Services = services;
        }
    }
}
