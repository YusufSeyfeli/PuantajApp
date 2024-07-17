using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserOperationClaimDtos
{
    public class UserOperationClaimGetListDto
    {
        public Guid UserOperationClaimGuidId { get; set; }
        public Guid UserGuidId { get; set; }
        public Guid OperationClaimGuidId { get; set; }
    }
}
