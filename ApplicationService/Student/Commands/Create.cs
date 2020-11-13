using AutoMapper;
using FluentValidation;
using MediatR;
using MediatRSample.Context;
using MediatRSample.Events;
using MediatRSample.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample.Student
{

    public class Create
    {
        public class CreateCommand : IRequest<StudentDto>
        {
            public string Name { get; set; }
        }

        public class CreateCommandValidator : AbstractValidator<CreateCommand>
        {
            public CreateCommandValidator()
            {
                RuleFor(customer => customer.Name).NotEmpty();
            }
        }

        public class CreateCommandHandler : IRequestHandler<CreateCommand, StudentDto>
        {
            private readonly MediateContext context;
            private readonly IMapper mapper;
            private readonly IMediator mediator;

            public CreateCommandHandler(IMapper mapper, IMediator mediator)
            {
                this.context = new MediateContext();
                this.mapper = mapper;
                this.mediator = mediator;
            }
            public async Task<StudentDto> Handle(CreateCommand createStudentCommand, CancellationToken cancellationToken)
            {
                var student = mapper.Map<Models.Student>(createStudentCommand);
                context.Students.Add(student);
                await context.SaveChangesAsync(cancellationToken);
                await mediator.Publish(new StudentCreatedEvent { Name = student.Name }, cancellationToken);
                return mapper.Map<StudentDto>(student);
            }
        }
      
    }
}
