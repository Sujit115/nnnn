

using Leapspark.Bootstrap.Dtos;
using Leapspark.Bootstrap.Services.MessageQueue;

namespace Leapspark.Auth.Handlers
{
    public class LeapsparkAuthEventHandlers
    {
        private readonly Events.Events events;
        private readonly IMessageQueue messageQueue;

        public LeapsparkAuthEventHandlers(
            Events.Events events,
            IMessageQueue messageQueue)
        {
            this.events = events;
            this.messageQueue = messageQueue;
            events.OnTokenIssued += this.OnTokenCreated;
        }

        public void OnTokenCreated(object source, EventDto<object> dto)
        {
            messageQueue.Send(dto);
        }

    }
}
