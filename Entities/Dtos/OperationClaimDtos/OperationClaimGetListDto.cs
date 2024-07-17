using Entities.Concrete;
using Entities.Dtos.CompetencyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OperationClaimDtos
{
    public class OperationClaimGetListDto
    {
        public Guid OperationClaimGuidId { get; set; }
        public string OperationClaimName { get; set; }
        public List<CompetencyGetListDto> GetCompetencyGetListDtos{ get; set; }
    }
}
