using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.ResponseModels
{
    public class SubjectResponseDto : ISubject
    {
        public int Id { get; set; }
        public string Name { get ; set ; }
        public string Code { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MarksDto Marks { get; set; }
        public int CreditHours { get; set; }

    }
}
