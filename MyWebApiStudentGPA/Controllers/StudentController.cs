using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentBL _studentBL;
        private readonly IStudentSubjectAssignmentBL _studentSubjectAssignmentBL;
        private readonly IStudentSubjectMarksBL _studentSubjectMarksBL;

        public StudentsController(IStudentBL studentBL, IStudentSubjectAssignmentBL studentSubjectAssignmentBL, IStudentSubjectMarksBL studentSubjectMarksBL)
        {
            _studentBL = studentBL;
            _studentSubjectAssignmentBL = studentSubjectAssignmentBL;
            _studentSubjectMarksBL = studentSubjectMarksBL;
        }

        [HttpPost]
        public IActionResult AddStudent(StudentRequestDto studentRequestDto)
        {
            var createdStudent = _studentBL.SaveStudent(studentRequestDto);
            return Ok("Student Added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentBL.DeleteStudent(id);

                return Ok("Student deleted");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _studentBL.GetStudents();
                return Ok(students);
            }
            catch (Exception ee)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditStudent(int id, StudentRequestDto studentRequestDto)
        {
            try
            {
                var updatedStudent = _studentBL.SaveStudent(id, studentRequestDto);

                return Ok(updatedStudent);
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
                var student = _studentBL.GetStudentDetails(id);
                return Ok(student);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/marks")]
        public IActionResult GetStudentMarksById(int id)
        {
            try
            {
                var student = _studentBL.GetStudentDetails(id);
                return Ok(student);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{studentId}/subjects")]
        public IActionResult GetStudentSubjects(int studentId)
        {
            try
            {
                var subjects = _studentSubjectAssignmentBL.GetStudentSubjects(studentId);

                if (subjects == null || subjects.Count == 0)
                {
                    return NotFound("No subjects found for this student");
                }

                var subjectResponseDto = subjects.Select(subject => new SubjectResponseDto
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Code = subject.Code,
                    CreditHours = subject.CreditHours,
                }).ToList();

                return Ok(subjectResponseDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{studentId}/subjects/{subjectId}/marks")]
        public IActionResult GetStudentSubjectMarks(int studentId, int subjectId)
        {
            try
            {
                var marks = _studentSubjectMarksBL.GetMarks(studentId, subjectId);

                if (marks == null)
                {
                    return NotFound($"Marks not found for student with ID {studentId} in subject with ID {subjectId}.");
                }
                var marksResponseDto = marks.Select(mark => new MarksResponseDto
                {
                    Id = mark.Id,
                    SID = mark.SID,
                    SubjectId = mark.SubjectId,
                    Marks  = mark.Marks
                }).ToList();

                return Ok(marksResponseDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
