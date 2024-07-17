using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.TallyDtos
{
    public class TallyUpdateDto:TallyDto
    {
        [Key]
        public Guid TallyGuidId { get; set; }
    }
}
