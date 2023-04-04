namespace BuildingMonitor.Messages
{
    public sealed class RequestFloorIds
    {
        public long RequestId { get; }

        public RequestFloorIds(long requestId)
        {
            RequestId = requestId;
        }
    }
}
