﻿using System.Collections.Generic;
using IEEETalks.Core.Entities;

namespace IEEETalks.Data.Repositories.Repositories.EventRepository
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();
    }
}