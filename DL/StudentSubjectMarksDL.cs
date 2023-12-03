using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;

namespace DL
{
    public class StudentSubjectMarksDL : IStudentSubjectMarksDL
    {
        public readonly StudentDbContext _stContext;
        public StudentSubjectMarksDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }
        public void DeleteMarks(int id)
        {
            var delete_marks = _stContext.markDbDto.Find(id);
            if (delete_marks == null)
            {
                throw new Exception("Student not found");
            }
            _stContext.markDbDto.Remove(delete_marks);
            _stContext.SaveChanges();
        }

        public MarksResponseDto SaveMarks(MarksRequestDto marksRequestDto)
        {
            var markDbDto = new MarksDbDto
            {
                SID = marksRequestDto.SID,
                SubjectId = marksRequestDto.SubjectId,
                Marks = marksRequestDto.Marks,
            };

            _stContext.Add(markDbDto);
            _stContext.SaveChanges();

            var marksAdded = new MarksResponseDto
            {
                Id = markDbDto.Id,
                SID = markDbDto.SID,
                SubjectId = marksRequestDto.SubjectId,
                Marks = marksRequestDto.Marks,
            };

            return marksAdded;
        }

        public MarksResponseDto SaveMarks(int id, MarksRequestDto marksRequestDto)
        {
            var existingStudent = _stContext.markDbDto.Find(id);
            if (existingStudent == null)
            {
                throw new Exception($"Student with id {id} not found");
            }

            existingStudent.SID = marksRequestDto.SID;
            existingStudent.SubjectId = marksRequestDto.SubjectId;
            existingStudent.Marks = marksRequestDto.Marks;
            _stContext.SaveChanges();

            var updatedMarksDto = new MarksResponseDto
            {
                Id = existingStudent.Id,
                SID = existingStudent.SID,
                SubjectId = existingStudent.SubjectId,
            };
            return updatedMarksDto;
        }

        public List<MarksResponseDto> GetMarks(int studentId, int subjectId)
        {

            var marks = _stContext.markDbDto
                .Where(ss => ss.SID == studentId && ss.SubjectId == subjectId)
                .Select(ss => new MarksResponseDto
                {
                    Id = ss.Id,
                    SID = ss.SID,
                    SubjectId = ss.SubjectId,
                    Marks = ss.Marks
                })
                .ToList();


            return marks;
        }

    }
}
