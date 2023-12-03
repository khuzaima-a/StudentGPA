using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubjectDL
    {
        public SubjectResponseDto SaveSubject(SubjectRequestDto subjectRequestDto);
        IEnumerable<SubjectResponseDto> GetSubjects();
        public void DeleteSubject(int id);
        public SubjectResponseDto SaveSubject(int id, SubjectRequestDto subjectRequestDto);
        SubjectResponseDto GetSubjectDetails(int id);
    }
}
