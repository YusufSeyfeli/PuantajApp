using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.StudentDtos
{
    public class StudentDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string ImageByteString { get; set; }
        public string StudentNo { get; set; }
        public string Faculty { get; set; }
        public string FacultyDepartment { get; set; }
        public int StudentClass { get; set; }
        public Guid JobUnitGuidId { get; set; }
    }
}
