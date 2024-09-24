using Leapspark.Bootstrap.Dtos;
using Leapspark.Bootstrap.Services.MessageQueue.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapspark.Bootstrap.EventHandlers
{
    public delegate void LeapsparkEventHandler<T>(object source, EventDto<T> dto) where T: class;
}
