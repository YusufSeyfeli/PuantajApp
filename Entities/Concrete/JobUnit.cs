using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class JobUnit
    {
        [Key]
        public Guid JobUnitGuidId { get; set; }
        public Guid JobDepartmentGuidId { get; set; }
        public string JobUnitName{ get; set; }
        //public List<User> Users { get; set; }
        public JobDepartment JobDepartment { get; set; }
        public List<Student> Students { get; set; }
        public List<UserJobUnit> UserJobUnits { get; set; }
    }
}
