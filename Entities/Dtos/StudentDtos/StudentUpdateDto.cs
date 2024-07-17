using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.StudentDtos
{
    public class StudentUpdateDto:StudentDto
    {
        [Key]
        public Guid StudentGuidId { get; set; }
    }
}
