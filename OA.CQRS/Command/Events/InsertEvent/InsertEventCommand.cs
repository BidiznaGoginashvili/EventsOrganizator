﻿using System;
using MediatR;

namespace OA.CQRS.Command.Events.InsertEvent
{
    public class InsertEventCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CategoryId { get; set; }

        public int CompanyId { get; set; }
    }
}
