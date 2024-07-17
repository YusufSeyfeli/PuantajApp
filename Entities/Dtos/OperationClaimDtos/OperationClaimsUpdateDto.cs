using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OperationClaimDtos
{
    public class OperationClaimUpdateDto : OperationClaimDto
    {
        [Key]
        public Guid OperationClaimGuidId { get; set; }
    }
}
