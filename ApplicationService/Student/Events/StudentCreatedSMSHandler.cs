using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample.Events
{
    public class StudentCreatedSMSHandler : INotificationHandler<StudentCreatedEvent>
    {
        public Task Handle(StudentCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"sms sent: {notification.Name}");
            return Task.CompletedTask;
        }
    }
}