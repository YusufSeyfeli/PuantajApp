using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserJobUnit
    {
        [Key]
        public Guid UserJobUnitGuidId { get; set; }
        public Guid  UserGuidId{ get; set; }
        public Guid JobUnitGuidId { get; set; }
        public User User { get; set; }
        public JobUnit JobUnit { get; set; }


    }
}
