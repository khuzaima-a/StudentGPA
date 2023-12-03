using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;

namespace DL
{
    public class StudentDL : IStudentDL
    {
        private readonly StudentDbContext _stContext;

        public StudentDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public StudentDetailSubjectResponseDto GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<StudentDbDto> GetStudents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentResponseDto> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto)
        {
            
            var studentdto = new StudentDbDto
            {
                Name = studentRequestDto.Name,
                RollNumber = studentRequestDto.RollNo,
                PhoneNumber = studentRequestDto.PhoneNumber
            };

            _stContext.studentDbDto.Add(studentdto);
            _stContext.SaveChanges();

            var student = new StudentResponseDto
            {
                Id = studentdto.Id,
                Name = studentdto.Name,
                RollNo = studentdto.RollNumber,
                PhoneNumber = studentdto.PhoneNumber,
                GPA = 0
            };

            return student;

        }
    }
}
