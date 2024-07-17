using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OperationCompetencyDtos
{
    public class OperationCompetencyDto
    {
        public Guid OperationClaimGuidId { get; set; }
        public Guid CompetencyGuidId { get; set; }
    }
}
