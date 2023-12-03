using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubjectBL
    {
        public SubjectResponseDto SaveSubject(SubjectRequestDto subjectRequestDto);
        public IEnumerable<SubjectResponseDto> GetSubjects();
        public void DeleteSubject(int id);
        public SubjectResponseDto SaveSubject(int id, SubjectRequestDto subjectRequestDto);
        public SubjectResponseDto GetSubjectDetails(int id);
    }
}
