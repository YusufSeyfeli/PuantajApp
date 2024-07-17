using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.JobUnitDtos
{
    public class JobUnitGetListDto
    {
        public Guid JobUnitGuidId { get; set; }
        public Guid JobDepartmentGuidId { get; set; }
        public string JobUnitName { get; set; }
    }
}
