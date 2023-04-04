namespace IoTDevice.Library.Messages
{
    public sealed class QueryTimeout
    {
        public static QueryTimeout Instance { get; } = new QueryTimeout();
        private QueryTimeout() { }
    }
}
