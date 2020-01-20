using System;

namespace OA.CQRS.Models.Events
{
    public class EventModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CategoryName { get; set; }

        public string CompanyName { get; set; }
    }
}
