using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;

namespace BL
{
    public class StudentSubjectBL : IStudentSubjectAssignmentBL
    {
        private readonly IStudentSubjectAssignmentDL _studentSubjectAssignmentDL;
        public StudentSubjectBL(IStudentSubjectAssignmentDL studentSubjectAssignmentDL)
        {
            _studentSubjectAssignmentDL = studentSubjectAssignmentDL;
        }
        public StudentSubjectAssignmentResponseDto SaveAssignment(StudentSubjectAssignmentRequestDto studentSubjectAssignmentRequestDto)
        {
            var createdAssignment = _studentSubjectAssignmentDL.SaveAssignment(studentSubjectAssignmentRequestDto);
            return createdAssignment;
        }

        public StudentSubjectAssignmentResponseDto SaveAssignment(int id, StudentSubjectAssignmentRequestDto studentSubjectAssignmentRequestDto)
        {
            var updated = _studentSubjectAssignmentDL.SaveAssignment(id, studentSubjectAssignmentRequestDto);
            return updated;
        }
        public void deleteStudentSubjectAssignment(int id)
        {
            _studentSubjectAssignmentDL.deleteStudentSubjectAssignment(id);
        }

        public List<SubjectResponseDto> GetStudentSubjects(int studentId)
        {
            var studentSubjects = _studentSubjectAssignmentDL.GetSubjectsForStudent(studentId);

            var subjectResponseDtos = studentSubjects.Select(subject => new SubjectResponseDto
            {
                Id = subject.Id,
                Name = subject.Name,
                Code = subject.Code,
                CreditHours = subject.CreditHours,
            }).ToList();

            return subjectResponseDtos;
        }

    }
}
