using Core.Interfaces;
using Core.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentBL _studentBL;

        public StudentsController(IStudentBL studentBL)
        {
            _studentBL = studentBL;
        }

        [HttpPost]
        public IActionResult AddStudent(StudentRequestDto studentRequestDto)
        {
            var createdStudent = _studentBL.SaveStudent(studentRequestDto);
            return Ok($"Student created{createdStudent}");
        }

      
      
        
    }
}
