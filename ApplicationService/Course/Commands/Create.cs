using AutoMapper;
using FluentValidation;
using MediatR;
using MediatRSample.Context;
using MediatRSample.Events;
using MediatRSample.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample.Course
{
    public class Create
    {
        public class CreateCommand : IRequest<CourseDto>
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

        public class CreateCommandHandler : IRequestHandler<CreateCommand, CourseDto>
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
            public async Task<CourseDto> Handle(CreateCommand createCommand, CancellationToken cancellationToken)
            {
                var course = mapper.Map<Models.Course>(createCommand);
                context.Courses.Add(course);
                await context.SaveChangesAsync(cancellationToken);
                return mapper.Map<CourseDto>(course);
            }
        }

    }
}
