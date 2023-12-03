using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;

namespace BL
{
    public class StudentSubjectMarksBL : IStudentSubjectMarksBL
    {
        public readonly IStudentSubjectMarksDL _studentSubjectMarksDL;
        public StudentSubjectMarksBL(IStudentSubjectMarksDL studentSubjectMarksDL)
        {
            _studentSubjectMarksDL = studentSubjectMarksDL;
        }
        public void DeleteMarks(int id)
        {
           _studentSubjectMarksDL.DeleteMarks(id);
        }

        public MarksResponseDto SaveMarks(MarksRequestDto marksRequestDto)
        {
            var marks = _studentSubjectMarksDL.SaveMarks(marksRequestDto);
            return(marks);
        }

        public MarksResponseDto SaveMarks(int id, MarksRequestDto marksRequestDto)
        {
            var updated = _studentSubjectMarksDL.SaveMarks(id, marksRequestDto);
            return updated;
        }
        public List<MarksResponseDto> GetMarks(int studentId, int subjectId)
        {
            var marks = _studentSubjectMarksDL.GetMarks(studentId, subjectId);

            return marks;
        }
    }
}
