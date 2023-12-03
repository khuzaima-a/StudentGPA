using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentSubjectAssignmentBL
    {
        public StudentSubjectAssignmentResponseDto SaveAssignment(StudentSubjectAssignmentRequestDto studentSubjectAssignmentRequestDto);
        public StudentSubjectAssignmentResponseDto SaveAssignment(int id, StudentSubjectAssignmentRequestDto studentSubjectAssignmentRequestDto);
        void deleteStudentSubjectAssignment(int id);
        public List<SubjectResponseDto> GetStudentSubjects(int studentId);
    }
}
