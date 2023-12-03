using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentDL
    {
        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto);  
        IEnumerable<StudentResponseDto> GetStudents();
        void DeleteStudent(int id);
        public StudentResponseDto GetStudentDetails(int id);
        public StudentResponseDto SaveStudent(int id, StudentRequestDto studentRequestDto);
    }
}
