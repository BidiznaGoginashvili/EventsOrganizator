using MediatR;

namespace OA.CQRS.Command.Events.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteEventCommand(int id)
        {
            Id = id;
        }
    }
}
