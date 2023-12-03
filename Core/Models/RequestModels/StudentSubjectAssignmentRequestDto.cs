using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.RequestModels
{
    public class StudentSubjectAssignmentRequestDto : IStudentSubjectAssignment
    {
        public int StudentId { get; set; }
        public int SubjectId {  get; set; }
    }
}
