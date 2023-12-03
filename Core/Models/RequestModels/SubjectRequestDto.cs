using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.RequestModels
{
    public class SubjectRequestDto : ISubject
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int CreditHours { get; set; }    
    }
}
