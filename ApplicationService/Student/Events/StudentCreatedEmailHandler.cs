using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample.Events
{
    public class StudentCreatedEmailHandler : INotificationHandler<StudentCreatedEvent>
    {
        public Task Handle(StudentCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"mail sent: {notification.Name}");
            return Task.CompletedTask;
        }
    }
}