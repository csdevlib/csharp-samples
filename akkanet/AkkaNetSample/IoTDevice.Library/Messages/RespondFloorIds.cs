using System.Collections.Immutable;

namespace IoTDevice.Library.Messages
{
    public sealed class RespondFloorIds
    {
        public long RequestId { get; }
        public IImmutableSet<string> Ids { get; }

        public RespondFloorIds(long requestId, ImmutableHashSet<string> ids)
        {
            RequestId = requestId;
            Ids = ids;
        }
    }
}
