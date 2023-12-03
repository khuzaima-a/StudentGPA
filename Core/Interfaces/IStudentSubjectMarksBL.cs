using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentSubjectMarksBL
    {
        public MarksResponseDto SaveMarks(MarksRequestDto marksRequestDto);
        public MarksResponseDto SaveMarks(int id, MarksRequestDto marksRequestDto);
        void DeleteMarks(int id);
        public List<MarksResponseDto> GetMarks(int studentId, int subjectId);
    }
}
