using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.JobUnitDtos
{
    public class JobUnitDto
    {
        public Guid JobDepartmentGuidId { get; set; }
        public string JobUnitName { get; set; }
    }
}
