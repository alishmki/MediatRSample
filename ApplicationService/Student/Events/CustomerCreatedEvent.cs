using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MediatRSample.Events
{
    public class StudentCreatedEvent : INotification
    {
        public string Name { get; set; }
    }
}