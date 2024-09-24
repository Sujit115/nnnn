using Leapspark.Bootstrap.Dtos;
using Leapspark.Bootstrap.EventHandlers;
using System;

namespace Leapspark.Auth.Events
{
    public class Events
    {
        public event LeapsparkEventHandler<object> OnTokenIssued;

        public void TokenIssued(object source, object data, string sub)
        {
            var eventDto = new EventDto<object>()
            {
                Data = data,
                DateTime = DateTime.Now,
                EventName = "token-issued",
                Sub = sub,
                Id = Guid.NewGuid().ToString(),
            };

            OnTokenIssued(source, eventDto);
        }
    }
}
