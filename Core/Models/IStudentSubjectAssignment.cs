using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
   interface IStudentSubjectAssignment
    {
        public int StudentId {  get; set; }
        public int SubjectId { get; set; }
    }
}
