using Core.Interfaces;
using Core.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IStudentSubjectMarksBL _studentSubjectMarks;
        public MarksController(IStudentSubjectMarksBL studentSubjectMarks)
        {
            _studentSubjectMarks = studentSubjectMarks;
        }

        [HttpPost]
        public IActionResult AddMarks(MarksRequestDto marksRequestDto)
        {
            var createdMarks = _studentSubjectMarks.SaveMarks(marksRequestDto);
            return Ok("Marks addded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMarks(int id)
        {
            try { 
                _studentSubjectMarks.DeleteMarks(id);
                 return Ok("Marks deleted");
            }catch(Exception e)
            {
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("{id}")]
        public IActionResult EditMarks(int id,  MarksRequestDto marksRequestDto)
        {
            try
            {
                var edit = _studentSubjectMarks.SaveMarks(id, marksRequestDto);
                return Ok("Markts Edit : Success");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }



    }
}
