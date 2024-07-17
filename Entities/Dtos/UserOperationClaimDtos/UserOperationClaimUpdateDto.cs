using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserOperationClaimDtos
{
    public class UserOperationClaimUpdateDto : UserOperationClaimDto
    {
        [Key]
        public Guid UserOperationClaimGuidId { get; set; }
    }
}
