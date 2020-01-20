using System;

namespace OA.DATA.Events
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Category.Category Category { get; set; }

        public int CategoryId { get; set; }

        public Company.Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
