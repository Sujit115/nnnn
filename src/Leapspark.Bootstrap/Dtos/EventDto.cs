namespace Leapspark.Bootstrap.Dtos
{
    public class EventDto<T> where T : class
    {
        public string Id { get; set; }
        public string Sub { get; set; }
        public string EventName { get; set; }
        public T Data { get; set; }
        public DateTime DateTime { get; set; }
    }
}
