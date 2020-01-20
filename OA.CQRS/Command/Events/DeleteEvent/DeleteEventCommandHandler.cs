using MediatR;
using OA.DATA.Events;
using OA.REPO.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OA.CQRS.Command.Events.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        #region Fields

        private readonly IRepository<Event> _eventsRepository;

        #endregion

        #region Ctor

        public DeleteEventCommandHandler(IRepository<Event> eventsRepository) 
        {
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var @event = _eventsRepository.GetById(request.Id);

                _eventsRepository.Delete(@event);

                return Task.FromResult(Unit.Value);
            }
            catch (Exception exception)
            {
                throw (exception);
            }
        }

        #endregion
    }
}
