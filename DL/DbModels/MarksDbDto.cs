using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class MarksDbDto
    {
        [Key]
        public int Id {  get; set; }
        public int SID { get; set; }
        public int SubjectId { get; set; }
        public int Marks { get; set; }
        public StudentSubjectDbDto studentSubjectDbDto { get; set; }
    }
}
