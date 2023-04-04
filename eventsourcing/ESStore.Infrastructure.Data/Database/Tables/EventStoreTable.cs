using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ESStore.Infrastructure.Data.Database.Tables
{
    public class EventStoreTable
    {   
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string AggregateId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string EventId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string EventType { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string EventMetadata { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string EventData { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string EventDate { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string StreamId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string StreamType { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string StreamData { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string CreatedDate { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string CreatedBy { get; set; }

        [BsonRepresentation(BsonType.String)]
        public int Timestamp { get; set; }
    }
}
