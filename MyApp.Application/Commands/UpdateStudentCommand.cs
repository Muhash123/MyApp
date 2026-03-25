using MediatR;
using MyApp.Application.Interfaces;
using MyApp.Core.Enteties;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Commands
{
    public record UpdateStudentCommand(int Id,Student Student) : IRequest<Student>;
    public class UpdateStudentCommandHandler(IStudentRepository studentRepository) : IRequestHandler<UpdateStudentCommand, Student>
    {
  

        public Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
           return studentRepository.UpdateStudentAsync(request.Id,request.Student);
        }
    }
}
