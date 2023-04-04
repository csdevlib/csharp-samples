using System;
using DDD.Library.Core.Interfaces;
using DDD.Library.ValueObjects;

namespace DDD.Library
{
    public struct TrackingProps : ITrackingProps
    {
        public bool IsNew { get; set; }
        public bool IsDirty { get; set; }

        public TrackingProps()
        {
            IsNew = false;
            IsDirty = false;
        }

        public void SetAsNew()
        {            
            IsNew = true;
            IsDirty = false;            
        }

        public void SetAsDirty()
        {            
            IsDirty = true;
        }
    }

    public abstract class Entity : IEntity
    {
        private IdValueObject _id { get; set; }
        private TrackingProps _trackingProps { get; set; }
        private AuditValueObject _audit { get; set; }

        public abstract void BusinessRules();
        
        protected Entity(string createdBy)
        {
            if (string.IsNullOrEmpty(createdBy)) throw new NullReferenceException("Props cannot be null");

            this._id = IdValueObject.Create();
            
            this._trackingProps = new TrackingProps();

            this._trackingProps.SetAsNew();

            this.BusinessRules();

            this._audit = AuditValueObject.Create(createdBy);
        }


        public void SetId(string id)
        {
            this._id = IdValueObject.SetId(id);
        }

        public IdValueObject getId()
        {
            return this._id;
        }


        public ITrackingProps GetTrackingProps()
        {
            return this._trackingProps;
        }

        protected static bool EqualOperator(Entity left, Entity right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }

            if (right is null) throw new ArgumentNullException("Right value cannot be null");

            return ReferenceEquals(left, null) || left.Equals(right);

        }

        protected static bool NotEqualOperator(Entity left, Entity right)
        {
            return !(EqualOperator(left, right));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            return item._id == this._id;
        }
     

        public Entity? GetCopy()
        {
            return this.MemberwiseClone() as Entity;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

