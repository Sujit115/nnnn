using Leapspark.Bootstrap.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Leapspark.Bootstrap.Services.MessageQueue
{
    public interface IMessageQueue
    {
        public void Send<T>(EventDto<T> eventDto) where T : class;
        public void OnReceived<T>(Action<EventDto<T>> action) where T : class;
    }
}
