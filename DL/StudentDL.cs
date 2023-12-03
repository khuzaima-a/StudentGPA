using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class StudentDL : IStudentDL
    {
        private readonly StudentDbContext _stContext;

        public StudentDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public double CalculateGpa(int studentId)
        {
            var studentDbDto = _stContext.studentDbDto
                .Include(student => student.studentSubjects)
                .ThenInclude(studentSubject => studentSubject.SubjectDbDto)
                .Include(student => student.studentSubjects)
                .ThenInclude(studentSubject => studentSubject.marksDbDto)
                .FirstOrDefault(student => student.Id == studentId);

            if (studentDbDto == null || !studentDbDto.studentSubjects.Any())
            {
                return 0; 
            }

            double totalGrades = 0;
            double creditHours = 0;

            foreach (var subjectDto in studentDbDto.studentSubjects)
            {
                double gradePoints = Get_GPA(subjectDto.marksDbDto?.Marks ?? 0);

                totalGrades += gradePoints * subjectDto.SubjectDbDto.CreditHour;
                creditHours += subjectDto.SubjectDbDto.CreditHour;
            }

            if (creditHours == 0)
            {
                return 0;
            }

            return (totalGrades / creditHours);
        }

        private static double Get_GPA(int marks)
        {
            if (marks >= 85)
            {
                return 4.0;
            }
            else if (marks >= 80)
            {
                return 3.7;
            }
            else if (marks >= 75)
            {
                return 3.3;
            }
            else if (marks >= 70)
            {
                return 3.0;
            }
            else if(marks >= 65)
            {
                return 2.7; 
            }
            else if(marks >= 60)
            {
                return 2.3;
            }
            else if(marks >= 55)
            {
                return 2.0;
            }
            else if(marks >= 50)
            {
                return 1.7;
            }
            else
            {
                return 0.0;
            }
        }


        public void DeleteStudent(int id)
        {
            var student = _stContext.studentDbDto.Find(id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }

            var assigments = _stContext.studentSubjectDbDto
                .Where(assignment => assignment.SID == id);
            var marks = _stContext.markDbDto
                .Where(mark => mark.SID == id);

            _stContext.studentSubjectDbDto.RemoveRange(assigments);
            _stContext.markDbDto.RemoveRange(marks);
            _stContext.studentDbDto.Remove(student);
            _stContext.SaveChanges();
        }

        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto)
        {
            if (_stContext.studentDbDto.Any(s => s.RollNumber == studentRequestDto.RollNo))
            {
                throw new Exception("Student with the same roll number already exists");
            }

            var studentDbDto = new StudentDbDto
            {
                Name = studentRequestDto.Name,
                RollNumber = studentRequestDto.RollNo,
                PhoneNumber = studentRequestDto.PhoneNumber,
            };

            _stContext.studentDbDto.Add(studentDbDto);
            _stContext.SaveChanges();

            var StudentDto = new StudentResponseDto
            {
                Id = studentDbDto.Id,
                Name = studentDbDto.Name,
                RollNo = studentDbDto.RollNumber,
                PhoneNumber = studentDbDto.PhoneNumber,
                GPA = CalculateGpa(studentDbDto.Id)
            };

            return StudentDto;
        }


        public IEnumerable<StudentResponseDto> GetStudents()
        {
            return GetStudentsWithSubjects().Select(studentDb => new StudentResponseDto
            {
                Id = studentDb.Id,
                Name = studentDb.Name,
                RollNo = studentDb.RollNumber,
                PhoneNumber = studentDb.PhoneNumber,
                GPA = CalculateGpa(studentDb.Id),
                studentSubjects = studentDb.studentSubjects?.Select(subjectDto => new SubjectResponseDto
                {
                    Id = subjectDto.SubjectDbDto.id,
                    Name = subjectDto.SubjectDbDto.Name,
                    Code = subjectDto.SubjectDbDto.Code,
                    CreditHours = subjectDto.SubjectDbDto.CreditHour,
                    Marks = new MarksDto
                    {
                        Marks = subjectDto.marksDbDto?.Marks ?? 0
                    }
                }).ToList() ?? new List<SubjectResponseDto>()
            });
        }


        private IEnumerable<StudentDbDto> GetStudentsWithSubjects()
        {
            return _stContext.studentDbDto
        .Include(s => s.studentSubjects)
            .ThenInclude(ss => ss.SubjectDbDto)
        .Include(s => s.studentSubjects)
            .ThenInclude(ss => ss.marksDbDto)
        .ToList();
        }


        public StudentResponseDto SaveStudent(int id, StudentRequestDto studentRequestDto)
        {
            var existingStudent = _stContext.studentDbDto.Find(id);
            if (existingStudent == null)
            {
                throw new Exception("Student Not found");
            }

            existingStudent.Name = studentRequestDto.Name;
            existingStudent.PhoneNumber = studentRequestDto.PhoneNumber;
            existingStudent.RollNumber = studentRequestDto.RollNo;
            _stContext.SaveChanges();

            var updatedStudentDto = new StudentResponseDto
            {
                Id = existingStudent.Id,
                Name = existingStudent.Name,
                RollNo = existingStudent.RollNumber,
                PhoneNumber = existingStudent.PhoneNumber,
                GPA = CalculateGpa(id)
            };

            return updatedStudentDto;
        }

        public StudentResponseDto GetStudentDetails(int id)
        {
            var studentDbDto = _stContext.studentDbDto
                .Include(s => s.studentSubjects)
                .ThenInclude(ss => ss.SubjectDbDto)
                .Include(s => s.studentSubjects)
            .ThenInclude(ss => ss.marksDbDto)
                .FirstOrDefault(s => s.Id == id);

            if (studentDbDto == null)
            {
                return null;
            }

            var responseDto = new StudentResponseDto
            {
                Id = studentDbDto.Id,
                Name = studentDbDto.Name,
                RollNo = studentDbDto.RollNumber,
                PhoneNumber = studentDbDto.PhoneNumber,
                GPA = CalculateGpa(id),
                studentSubjects = studentDbDto.studentSubjects.Select(subjectDto => new SubjectResponseDto
                {
                    Id = subjectDto.SubjectDbDto.id,
                    Name = subjectDto.SubjectDbDto.Name,
                    Code = subjectDto.SubjectDbDto.Code,
                    CreditHours = subjectDto.SubjectDbDto.CreditHour,
                    Marks = new MarksDto
                    {
                        Marks = subjectDto.marksDbDto?.Marks ?? 0
                    }
                }).ToList()

            };

            return responseDto;
        }
    }
}
