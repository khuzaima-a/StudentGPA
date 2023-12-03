using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.ResponseModels
{
    public class StudentResponseDto : IStudent
    {
        public int Id { get; set; }
        public string Name { get ; set ; }
        public string RollNo { get ; set ; }
        public double GPA { get; set ; }
        public string PhoneNumber { get ; set ; }
        public List<SubjectResponseDto> studentSubjects { get; set; } = new List<SubjectResponseDto>();
    }


    public class StudentDetailSubjectResponseDto:StudentResponseDto
    {
        public List<SubjectResponseDto> SubjectsAssociated { get; set; }
    }
}
