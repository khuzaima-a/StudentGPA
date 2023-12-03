using Core.Interfaces;
using Core.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectBL _subjectBL;
        public SubjectController(ISubjectBL subjectBL) {
            _subjectBL = subjectBL;
        }


        [HttpPost]
        public IActionResult AddStudent(SubjectRequestDto subjectRequestDto)
        {
            var student = _subjectBL.SaveSubject(subjectRequestDto);
            return Ok("Student Added");  
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            try
            {
                var subjects = _subjectBL.GetSubjects();
                return Ok(subjects);
            }
            catch (Exception e)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            try
            {
                _subjectBL.DeleteSubject(id);
                return Ok("Subject deleted");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditSubject(int id,  SubjectRequestDto subjectRequestDto)
        {
            try
            {
                var updatedSubject = _subjectBL.SaveSubject(id, subjectRequestDto);

                return Ok(updatedSubject);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var subject = _subjectBL.GetSubjectDetails(id);
                return Ok(subject);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
