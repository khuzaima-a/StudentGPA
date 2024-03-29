﻿using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentBL
    {
        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto);
        public StudentDetailSubjectResponseDto GetStudent(int id);
        public IEnumerable<StudentResponseDto> GetStudents();
        public void DeleteStudent(int id);
        public StudentResponseDto SaveStudent(int id, StudentRequestDto studentRequestDto);
        //public StudentResponseDto GetStudentDetails(int id);
        public StudentResponseDto GetStudentDetails(int id);
    }
}
