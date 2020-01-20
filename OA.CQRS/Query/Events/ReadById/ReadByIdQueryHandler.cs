using MediatR;
using OA.DATA.Events;
using System.Threading;
using OA.CQRS.AutoMapper;
using OA.REPO.Repository;
using OA.CQRS.Models.Events;
using System.Threading.Tasks;

namespace OA.CQRS.Query.Events.ReadById
{
    public class ReadByIdQueryHandler : IRequestHandler<ReadByIdQuery,EventModel>
    {
        #region Fields

        private readonly IRepository<Event> _eventsRepository;

        #endregion

        #region Ctor

        public ReadByIdQueryHandler(IRepository<Event> eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public Task<EventModel> Handle(ReadByIdQuery request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.GetById(request.Id);

            var model = @event.MapEventToModel();

            return Task.FromResult(model);
        }

        #endregion
    }
}
