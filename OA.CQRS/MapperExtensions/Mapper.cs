using OA.DATA.Events;
using OA.CQRS.Models.Events;
using System.Collections.Generic;
using System.Linq;

namespace OA.CQRS.AutoMapper
{
    public static class Mapper 
    {
        public static IEnumerable<EventModel> MapEventCollectionToModel(this IEnumerable<Event> source) 
        {
            return source.Select(@event => new EventModel()
            {
                Id = @event.Id,
                Name = @event.Name,
                Price = @event.Price,
                Description = @event.Description,
                EndDate = @event.EndDate,
                StartDate = @event.StartDate
                //CategoryName = @event.Category.Name,
                //CompanyName = @event.Company.Name
            }).ToList();
        }

        public static EventModel MapEventToModel(this Event source) 
        {
            EventModel destination= new EventModel();
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Price = source.Price;
            destination.Description = source.Description;
            destination.EndDate = source.EndDate;
            destination.StartDate = source.StartDate;
            destination.CategoryName = source.Category.Name;
            destination.CompanyName = source.Company.Name;

            return destination;
        }
    }
}
