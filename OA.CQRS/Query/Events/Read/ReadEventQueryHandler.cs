using System;
using MediatR;
using System.Linq;
using OA.DATA.Events;
using System.Threading;
using OA.REPO.Repository;
using OA.CQRS.Models.Events;
using System.Threading.Tasks;
using System.Collections.Generic;
using OA.CQRS.AutoMapper;

namespace OA.CQRS.Query.Events.Read
{
    public class ReadEventQueryHandler : IRequestHandler<ReadEventQuery, IEnumerable<EventModel>>
    {
        #region Fields

        private readonly IRepository<Event> _eventsRepository;

        #endregion

        #region Ctor

        public ReadEventQueryHandler(IRepository<Event> eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public Task<IEnumerable<EventModel>> Handle(ReadEventQuery request, CancellationToken cancellationToken)
        {
            try 
            {
                var events = _eventsRepository.GetAll();

                if (!string.IsNullOrWhiteSpace(request.Name))
                    events = events.Where(@event => @event.Name.Contains(request.Name));
                if (request.StartDate.HasValue)
                    events = events.Where(@event => @event.StartDate == request.StartDate.Value);
                if (request.EndDate.HasValue)
                    events = events.Where(@event => @event.EndDate == request.EndDate.Value);

                events = events.OrderBy(@event => @event.Id);

                var source = events.ToList();

                var model = source.MapEventCollectionToModel();

                return Task.FromResult(model);
            }
            catch(Exception ex) 
            {
                var x = ex;
                return default;
            }
        }

        #endregion
    }
}
