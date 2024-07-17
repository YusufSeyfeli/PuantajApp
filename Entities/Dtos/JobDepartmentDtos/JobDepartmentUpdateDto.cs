using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.JobDepartmentDtos
{
    public class JobDepartmentUpdateDto: JobDepartmentDto
    {
        [Key]
        public Guid JobDepartmentGuidId { get; set; }
    }
}
