using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    interface ISubject
    {
        string Name { get; set; }   
        string Code { get; set; }
        int CreditHours { get; set; }
    }
}
