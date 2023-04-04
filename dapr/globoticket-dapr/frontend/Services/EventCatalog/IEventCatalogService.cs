﻿using GloboTicket.Frontend.Models.Api;

namespace GloboTicket.Frontend.Services;

public interface IEventCatalogService
{
    Task<IEnumerable<Event>> GetAll();

    Task<Event> GetEvent(Guid id);

}
