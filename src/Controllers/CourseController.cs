using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatRSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MediatRSample.Controllers
{
    [Route("course")]
    public class CourseController : Controller
    {
        private readonly IMediator mediator;

        public CourseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Course.Create.CreateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            CourseDto studentDto = await mediator.Send(command);
            return Ok(new { studentDto.Id, studentDto });
        }

    }
}