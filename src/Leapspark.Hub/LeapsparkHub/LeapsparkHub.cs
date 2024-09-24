using Leapspark.Bootstrap.Dtos;
using Leapspark.Bootstrap.Services.MessageQueue;

namespace Leapspark.Hub.LeapsparkHub
{
    public class LeapsparkHub
    {
        public LeapsparkHub(IMessageQueue messageQueue)
        {
            messageQueue.OnReceived<object>(onReceived);
        }

        private void onReceived(EventDto<object> e)
        {
            Console.WriteLine("received");
        }
    }
}
