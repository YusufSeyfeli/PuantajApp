using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OperationCompetency
    {
        [Key]
        public Guid OperationCompetencyGuidId { get; set; }
        public Guid OperationClaimGuidId { get; set; }
        public Guid CompetencyGuidId{ get; set; }
        public OperationClaim OperationClaim { get; set; }
        public Competency Competency { get; set; }


    }
}
