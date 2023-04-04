using System;
namespace DDD.Library.Core.Interfaces
{
	public interface ITrackingProps
	{
		public bool IsNew { get; }
        public bool IsDirty { get; }
    }
}

