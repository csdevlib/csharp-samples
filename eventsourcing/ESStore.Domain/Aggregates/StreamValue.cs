using BeyondNet.Patterns.NetDdd.Core.Impl;
using System.Collections.Generic;

namespace ESStore.Domain.Aggregates
{
    public class StreamValue : AbstractValueObject
    {
        public string StreamId { get; private set; }
        public string StreamType { get; private set; }
        public object StreamData { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return StreamId;
            yield return StreamType;
            yield return StreamData;
        }

        private StreamValue(string streamId, string streamType, string streamData)
        {
            StreamId = streamId;
            StreamType = streamType;
            StreamData = streamData;
        }

        public static StreamValue Create(string streamId, string streamType, string streamData)
        {
            return new StreamValue(streamId, streamType, streamData);
        }
    }
}
