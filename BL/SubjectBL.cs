using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;

namespace BL
{
    public class SubjectBl : ISubjectBL
    {
        private readonly ISubjectDL _subjectDL;
        public SubjectBl(ISubjectDL subjectDL) 
        {
            _subjectDL = subjectDL;
        }

        public IEnumerable<SubjectResponseDto> GetSubjects()
        {
            var subjectsDb = _subjectDL.GetSubjects();
            var subjectResponseDtos = subjectsDb.Select(subjectDb => new SubjectResponseDto
            {
                Id = subjectDb.Id,
                Name = subjectDb.Name,
                Code = subjectDb.Code,
                CreditHours =   subjectDb.CreditHours,
            });
            return subjectResponseDtos;
        }

        public SubjectResponseDto SaveSubject(SubjectRequestDto subjectRequestDto)
        {
            var SubjectDto = _subjectDL.SaveSubject(subjectRequestDto);
            return SubjectDto;
        }

        public void DeleteSubject(int id)
        {
            _subjectDL.DeleteSubject(id);
        }

        public SubjectResponseDto SaveSubject(int id, SubjectRequestDto subjectRequestDto)
        {
            var updated = _subjectDL.SaveSubject(id, subjectRequestDto);
            return updated;
        }

        public SubjectResponseDto GetSubjectDetails(int id)
        {
            var subjectDbDto = _subjectDL.GetSubjectDetails(id);

            var subjectResponseDto = new SubjectResponseDto
            {
                Id= subjectDbDto.Id,
                Name = subjectDbDto.Name,
                Code = subjectDbDto.Code,
                CreditHours = subjectDbDto.CreditHours
            };

            return subjectResponseDto;
        }
    }
}
