using MediatR;
using OA.CQRS.Models.Events;

namespace OA.CQRS.Query.Events.ReadById
{
    public class ReadByIdQuery : IRequest<EventModel>
    {
        public int Id { get; set; }

        public ReadByIdQuery(int id)
        {
            Id = id;
        }
    }
}
