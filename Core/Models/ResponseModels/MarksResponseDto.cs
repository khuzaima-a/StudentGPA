using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ResponseModels
{
    public class MarksResponseDto: StudentSubjectMarksDto
    {
        public int Id {  get; set; }
        public int SID { get; set; }
        public int SubjectId { get; set; }
        public int Marks { get; set; }
    }
}
