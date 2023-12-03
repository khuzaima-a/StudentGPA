using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ResponseModels
{
    public class StudentSubjectAssignmentResponseDto : IStudentSubjectAssignment
    {
        public int Id {  get; set; }
        public int StudentId {  get; set; }
        public int SubjectId {  get; set; }
    }
}
