using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;

namespace BL
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentDL _studentDL;

        public StudentBL(IStudentDL studentDL)
        {
            _studentDL = studentDL;
        }

        public StudentDetailSubjectResponseDto GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentResponseDto> GetStudents()
        {
            throw new NotImplementedException();
        }

        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto)
        {
            var student = _studentDL.SaveStudent(studentRequestDto);

            return student;
        }


    }
}
