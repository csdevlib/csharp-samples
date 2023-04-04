using BeyondNet.Patterns.NetDdd.Core.Impl;

namespace ESStore.Domain.Aggregates
{
    public class EEventStoreStatus : Enumeration
    {
        public static EEventStoreStatus Active = new(1, nameof(Active));
        public static EEventStoreStatus Inactive = new(2, nameof(Inactive));

        public EEventStoreStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
