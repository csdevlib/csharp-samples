using System.Collections.Generic;

namespace BackOffice.Shared.Domain.Interfaces
{

    public interface IDomainEventSource
    {
        public IReadOnlyList<object> Get();
    }
}
