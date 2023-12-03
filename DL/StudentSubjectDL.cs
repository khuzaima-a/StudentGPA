using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StudentSubjectDL : IStudentSubjectAssignmentDL
    {
        private readonly StudentDbContext _stContext;
        public StudentSubjectDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public StudentSubjectAssignmentResponseDto SaveAssignment(StudentSubjectAssignmentRequestDto studentSubjectAssignmentRequestDto)
        {
            var existingAssignment = _stContext.studentSubjectDbDto
                .FirstOrDefault(a => a.SID == studentSubjectAssignmentRequestDto.StudentId
                    && a.SubjectId == studentSubjectAssignmentRequestDto.SubjectId);

            if (existingAssignment != null)
            {
                throw new InvalidOperationException($"Assignment already exists for StudentId: {studentSubjectAssignmentRequestDto.StudentId} and SubjectId: {studentSubjectAssignmentRequestDto.SubjectId}");
            }

            var existingStudent = _stContext.studentDbDto
                .FirstOrDefault(s => s.Id == studentSubjectAssignmentRequestDto.StudentId);

            var existingSubject = _stContext.subjectDbDto
                .FirstOrDefault(sub => sub.id == studentSubjectAssignmentRequestDto.SubjectId);

            if (existingStudent == null || existingSubject == null)
            {
                throw new InvalidOperationException("Student or Subject not found for assignment creation");
            }

            var studentSubjectDbDto = new StudentSubjectDbDto
            {
                SID = studentSubjectAssignmentRequestDto.StudentId,
                studentDbDto = existingStudent,
                SubjectId = studentSubjectAssignmentRequestDto.SubjectId,
                SubjectDbDto = existingSubject,
            };

            _stContext.studentSubjectDbDto.Add(studentSubjectDbDto);
            _stContext.SaveChanges();

            var createdStudentSubjectAssignmentDto = new StudentSubjectAssignmentResponseDto
            {
                Id = studentSubjectDbDto.Id,
                StudentId = studentSubjectDbDto.SID,
                SubjectId = studentSubjectDbDto.SubjectId,
            };

            return createdStudentSubjectAssignmentDto;
        }

        public StudentSubjectAssignmentResponseDto SaveAssignment(int id, StudentSubjectAssignmentRequestDto studentSubjectAssignmentRequestDto)
        {
            var existingStudent = _stContext.studentDbDto.FirstOrDefault(s => s.Id == studentSubjectAssignmentRequestDto.StudentId);
            var existingSubject = _stContext.subjectDbDto.FirstOrDefault(sub => sub.id == studentSubjectAssignmentRequestDto.SubjectId);
            var existingAssignment = _stContext.studentSubjectDbDto.Find(id);
            if (existingAssignment == null)
            {
                throw new Exception($"Student with id {id} not found");
            }
            existingAssignment.SID = studentSubjectAssignmentRequestDto.StudentId;
            existingAssignment.SubjectId = studentSubjectAssignmentRequestDto.SubjectId;
            existingAssignment.studentDbDto = existingStudent;
            existingAssignment.SubjectDbDto = existingSubject; 

            _stContext.SaveChanges();

            var updatedAssignemnt = new StudentSubjectAssignmentResponseDto
            {
                Id = existingAssignment.Id,
                StudentId = existingAssignment.SID,
                SubjectId = existingAssignment.SubjectId
            };
            return updatedAssignemnt;
        }
        public void deleteStudentSubjectAssignment(int id)
        {
            var deleteAssignment = _stContext.studentSubjectDbDto.Find(id);
            var marksToDelete = _stContext.markDbDto
                .Where(mark => mark.SID == deleteAssignment.SID && mark.SubjectId == deleteAssignment.SubjectId);

            if (deleteAssignment == null)
            {
                throw new Exception("Assignment not found");
            }

            _stContext.markDbDto.RemoveRange(marksToDelete);
            _stContext.studentSubjectDbDto.Remove(deleteAssignment);
            _stContext.SaveChanges();
        }

        public List<SubjectResponseDto> GetSubjectsForStudent(int studentId)
        {
            var subjects = _stContext.studentSubjectDbDto
                .Where(ss => ss.SID == studentId)
                .Select(ss => new SubjectResponseDto
                {
                    Id = ss.SubjectDbDto.id,
                    Name = ss.SubjectDbDto.Name,
                    Code = ss.SubjectDbDto.Code,
                    CreditHours = ss.SubjectDbDto.CreditHour
                })
                .ToList();

            return subjects;
        }

    }

}
