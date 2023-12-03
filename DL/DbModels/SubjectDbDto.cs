using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class SubjectDbDto
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CreditHour {  get; set; }

        public ICollection<StudentSubjectDbDto> StudentSubjects { get; set; } = new List<StudentSubjectDbDto>();
    }
}
