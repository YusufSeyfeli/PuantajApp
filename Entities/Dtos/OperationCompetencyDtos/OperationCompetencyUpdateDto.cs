using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OperationCompetencyDtos
{
    public class OperationCompetencyUpdateDto:OperationCompetencyDto
    {
        [Key]
        public Guid OperationCompetencyGuidId { get; set; }
    }
}
