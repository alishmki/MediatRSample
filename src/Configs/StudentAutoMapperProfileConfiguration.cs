using AutoMapper;
using MediatRSample.Models;

namespace MediatRSample.Controllers
{
   

    public class UserProfile : Profile
    {
        public UserProfile()
        {
     
            CreateMap<Student.Create.CreateCommand, Models.Student>();
            CreateMap<Models.Student, StudentDto>();

            CreateMap<Course.Create.CreateCommand, Models.Course>();
            CreateMap<Models.Course, CourseDto>();
          ;
        }
    }
}
