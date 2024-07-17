using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OperationClaimDtos
{
    public class OperationClaimGetUserDto
    {
        public Guid OperationClaimGuidId { get; set; }
        public string OperationClaimName { get; set; }
    }
}
