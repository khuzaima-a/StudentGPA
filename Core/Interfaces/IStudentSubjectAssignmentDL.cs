using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentSubjectAssignmentDL
    {
        public StudentSubjectAssignmentResponseDto SaveAssignment(StudentSubjectAssignmentRequestDto studentSubjectAssignmentRequestDto);
        public StudentSubjectAssignmentResponseDto SaveAssignment(int id, StudentSubjectAssignmentRequestDto studentSubjectAssignmentRequestDto);
        void deleteStudentSubjectAssignment(int id);
        public List<SubjectResponseDto> GetSubjectsForStudent(int studentId);
    }
}
