using MediatR;
using MyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Commands
{

    public record DeleteStudentCommand(int Id) : IRequest<string>;
    internal class DeleteStudentCommandHabdler(IStudentRepository studentRepository) : IRequestHandler<DeleteStudentCommand, string>
    {
        public async Task<string> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await studentRepository.DeleteStudentAsync(request.Id);
        }
    }
}
