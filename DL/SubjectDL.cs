using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;

namespace DL
{
    public class SubjectDL : ISubjectDL
    {
        private readonly StudentDbContext _stContext;
        public SubjectDL(StudentDbContext stContext) 
        { 
            _stContext = stContext;
        }

        IEnumerable<SubjectResponseDto> ISubjectDL.GetSubjects()
        {
            return GetSubjects().Select(subjectDb => new SubjectResponseDto
            {
                Id = subjectDb.id,
                Name = subjectDb.Name,
                Code = subjectDb.Code,
                CreditHours = subjectDb.CreditHour
            });
        }

        private IEnumerable<SubjectDbDto> GetSubjects()
        {
            return _stContext.subjectDbDto.AsEnumerable();
        }

        public SubjectResponseDto SaveSubject(SubjectRequestDto subjectRequestDto)
        {
            if (_stContext.subjectDbDto.Any(s => s.Name == subjectRequestDto.Name || s.Code == subjectRequestDto.Code))
            {
                throw new Exception("Subject with the same name or code already exists");
            }

            var subjectDbDto = new SubjectDbDto
            {
                Name = subjectRequestDto.Name,
                Code = subjectRequestDto.Code,
                CreditHour = subjectRequestDto.CreditHours
            };

            _stContext.subjectDbDto.Add(subjectDbDto);
            _stContext.SaveChanges();

            var createdSubject = new SubjectResponseDto
            {
                Name = subjectDbDto.Name,
                Code = subjectDbDto.Code,
                CreditHours = subjectDbDto.CreditHour
            };

            return createdSubject;
        }

        public void DeleteSubject(int id)
        {
            var subject = _stContext.subjectDbDto.Find(id);
            if (subject == null)
            {
                throw new Exception("Subject not found");
            }

            var assignmentsToDelete = _stContext.studentSubjectDbDto
                .Where(assignment => assignment.SubjectId == id);
            var marksToDelete = _stContext.markDbDto
                .Where(mark => mark.SID == id);

            _stContext.studentSubjectDbDto.RemoveRange(assignmentsToDelete);
            _stContext.markDbDto.RemoveRange(marksToDelete);
            _stContext.subjectDbDto.Remove(subject);
            _stContext.SaveChanges();
        }

        public SubjectResponseDto SaveSubject(int id, SubjectRequestDto subjectRequestDto)
        {
            var existingSubject = _stContext.subjectDbDto.Find(id);
            if (existingSubject == null)
            {
                throw new Exception($"Student with id {id} not found");
            }

            existingSubject.Name = subjectRequestDto.Name;
            existingSubject.Code = subjectRequestDto.Code;
            existingSubject.CreditHour = subjectRequestDto.CreditHours;
            _stContext.SaveChanges();

            var updatedSubjectDto = new SubjectResponseDto
            {
                Id = existingSubject.id,
                Name = existingSubject.Name,
                Code = existingSubject.Code,
                CreditHours = existingSubject.CreditHour
            };
            return updatedSubjectDto;
        }
        public SubjectResponseDto GetSubjectDetails(int id)
        {
            var subject = _stContext.subjectDbDto
                .FirstOrDefault(s => s.id == id);

            if (subject == null)
            {
                return null;
            }

            var responseDto = new SubjectResponseDto
            {
                Id = subject.id,
                Name = subject.Name,
                Code = subject.Code,
                CreditHours = subject.CreditHour
            };

            return responseDto;
        }
    }
}
