using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Queries;
using MyApp.Core.Enteties;

namespace MyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await mediator.Send(new GetAllStudentsQuery());
            return Ok(result);

        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {


            var result = await mediator.Send(new AddStudentCommand(student));

            return Ok(result);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var result = await mediator.Send(new DeleteStudentCommand(id));
            return Ok(result);
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            // Pass the 'id' from the URL AND the 'student' from the body
            var result = await mediator.Send(new UpdateStudentCommand(id, student));
            return Ok(result);
        }
    }
}