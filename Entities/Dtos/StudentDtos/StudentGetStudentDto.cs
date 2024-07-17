using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.StudentDtos
{
    public class StudentGetStudentDto
    {
        public Guid StudentGuidId { get; set; }
        public string ImageByteString { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string JobUnitGuidId { get; set; }
        public string StudentNo { get; set; }
    }
}
