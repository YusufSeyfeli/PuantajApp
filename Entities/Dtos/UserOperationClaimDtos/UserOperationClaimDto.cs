using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserOperationClaimDtos
{
    public class UserOperationClaimDto
    {
        public Guid UserGuidId { get; set; }
        public Guid OperationClaimGuidId { get; set; }
    }
}
