using MediatR;
using MyApp.Application.Interfaces;
using MyApp.Core.Enteties;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Commands
{
    public record AddStudentCommand(Student student):IRequest<Student>;
    public class AddStudentCommandHandler(IStudentRepository studentRepository) : IRequestHandler<AddStudentCommand, Student>
    {
        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
           return await studentRepository.AddStudentAsync(request.student);
        }
    }
}
