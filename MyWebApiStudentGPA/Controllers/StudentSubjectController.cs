using Core.Interfaces;
using Core.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectController : ControllerBase
    {
        public readonly IStudentSubjectAssignmentBL _studentSubjectAssignmentBL;
        public StudentSubjectController(IStudentSubjectAssignmentBL studentSubjectAssignmentBL)
        { 
            _studentSubjectAssignmentBL = studentSubjectAssignmentBL;
        }
        [HttpPost]
        public IActionResult CreateStdentSubjectAssignment(StudentSubjectAssignmentRequestDto studentSubjectRequestDto)
        {
            var createdStudent = _studentSubjectAssignmentBL.SaveAssignment(studentSubjectRequestDto);
            return Ok("Assignmnet created");
        }
        [HttpPut("{id}")]
        public IActionResult EditStudentSubjectAssignment(int id, StudentSubjectAssignmentRequestDto studentSubjectRequestDto)
        {
            try
            {
                var updated = _studentSubjectAssignmentBL.SaveAssignment(id, studentSubjectRequestDto);
                
                return Ok(updated);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            try
            {
                _studentSubjectAssignmentBL.deleteStudentSubjectAssignment(id);

                return Ok("Assignmnent deleted");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
