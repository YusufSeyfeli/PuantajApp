using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobDepartment
    {
        [Key]
        public Guid JobDepartmentGuidId { get; set; }
        public string  Name { get; set; }
        public List<JobUnit> JobUnits { get; set; }
    }
}
