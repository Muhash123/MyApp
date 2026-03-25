using MediatR;
using MyApp.Application.Interfaces;
using MyApp.Core.Enteties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Application.Queries
{

    public record GetAllStudentsQuery():IRequest<IEnumerable<Student>>;

    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return _studentRepository.GetAllStudentsAsync();
        }
    }



}



