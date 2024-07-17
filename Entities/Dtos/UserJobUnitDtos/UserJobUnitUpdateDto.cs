using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserJobUnitDtos
{
    public class UserJobUnitUpdateDto:UserJobUnitDto
    {
        [Key]
        public Guid UserJobUnitGuidId { get; set; }
    }
}
