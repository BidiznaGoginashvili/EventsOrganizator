using System;
using MediatR;
using OA.CQRS.Models.Events;
using System.Collections.Generic;

namespace OA.CQRS.Query.Events.Read
{
    public class ReadEventQuery : IRequest<IEnumerable<EventModel>>
    {
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
