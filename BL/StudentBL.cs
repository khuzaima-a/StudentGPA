using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;

namespace BL
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentDL _studentDL;

        public StudentBL(IStudentDL studentDL, IStudentSubjectMarksDL studentSubjectMarksDL)
        {
            _studentDL = studentDL;
        }

        public void DeleteStudent(int id)
        {
            _studentDL.DeleteStudent(id);

        }

        public StudentDetailSubjectResponseDto GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentResponseDto> GetStudents()
        {
            var studentsDb = _studentDL.GetStudents();

            var studentResponseDtos = studentsDb.Select(studentDb => new StudentResponseDto
            {
                Id = studentDb.Id,
                Name = studentDb.Name,
                RollNo = studentDb.RollNo,
                PhoneNumber = studentDb.PhoneNumber,
                GPA = studentDb. GPA,
                studentSubjects = studentDb.studentSubjects.Select(subjectDto => new SubjectResponseDto
                {
                    Id = subjectDto.Id,
                    Name = subjectDto.Name,
                    Code = subjectDto.Code,
                    CreditHours = subjectDto.CreditHours,
                    Marks = subjectDto.Marks
                }).ToList()
            });

            return studentResponseDtos;
        }

        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto)
        {
            var student = _studentDL.SaveStudent(studentRequestDto);

            return student;
        }
        public StudentResponseDto SaveStudent(int id, StudentRequestDto studentRequestDto)
        {
            var updated = _studentDL.SaveStudent(id, studentRequestDto);
            return updated;
        }

        public StudentResponseDto GetStudentDetails(int id)
        {
            var studentDbDto = _studentDL.GetStudentDetails(id);

            if (studentDbDto == null)
            {
                return studentDbDto;
            }


            var studentResponseDto = new StudentResponseDto
            {
                Id = studentDbDto.Id,
                Name = studentDbDto.Name,
                RollNo = studentDbDto.RollNo,
                GPA = studentDbDto. GPA,
                PhoneNumber = studentDbDto.PhoneNumber,
                studentSubjects = studentDbDto.studentSubjects.Select(subjectDto => new SubjectResponseDto
                {
                    Id = subjectDto.Id,
                    Name = subjectDto.Name,
                    Code = subjectDto.Code,
                    CreditHours = subjectDto.CreditHours,
                    Marks = subjectDto.Marks

                }).ToList()
            };

            return studentResponseDto;
        }

    }
}
