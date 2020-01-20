using MediatR;
using OA.DATA.Events;
using OA.REPO.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OA.CQRS.Command.Events.InsertEvent
{
    public class InsertEventCommandHandler : IRequestHandler<InsertEventCommand>
    {
        #region Fields

        private readonly IRepository<Event> _eventsRepository;

        #endregion

        #region Ctor

        public InsertEventCommandHandler(IRepository<Event> eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        #endregion

        #region Handler

        public Task<Unit> Handle(InsertEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
            }
            catch (Exception)
            {
                throw;
            }
            return default;
        }

        #endregion
    }
}
