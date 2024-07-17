using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OperationCompetencyDtos
{
    public class OperationCompetencyGetListDto
    {
        public Guid OperationCompetencyGuidId { get; set; }
        public Guid OperationClaimGuidId { get; set; }
        public Guid CompetencyGuidId { get; set; }
    }
}
