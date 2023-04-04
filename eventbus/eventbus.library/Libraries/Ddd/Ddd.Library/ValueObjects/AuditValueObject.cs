using System;

namespace DDD.Library.ValueObjects
{
    public struct AuditProps
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TimeSpan Timespan { get; set; }

        public AuditProps(string createdBy)
        {
            this.CreatedAt = new DateTime().ToUniversalTime();
            this.CreatedBy = createdBy;
            this.Timespan = new TimeSpan();
        }

        public void Update(string updatedBy)
        {
            this.UpdatedBy = updatedBy;
        }
    }

    public class AuditValueObject: ValueObject<AuditProps>
	{
        
        private  AuditValueObject(AuditProps props) : base(props)
        {          
            
        }

        public static AuditValueObject Create(string createdBy)
		{
            return new AuditValueObject(new AuditProps(createdBy));
		}

        public override void BusinessRules()
        {
      
        }

        public void Update(string updatedBy)
        {
            this.Value.Update(updatedBy);            
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value.CreatedBy;
            yield return this.Value.CreatedAt;
            yield return this.Value.UpdatedBy;
            yield return this.Value.UpdatedAt;
            yield return this.Value.Timespan;
        }

      
    }
}

