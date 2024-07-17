using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Competency
    {
        [Key]
        public Guid CompetencyGuidId { get; set; }
        public String Name{ get; set; }
        public List<OperationCompetency> OperationCompetencies { get; set; }

    }
}
