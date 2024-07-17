using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.LoggingDtos
{
    public class LoggingUpdateDto : LoggingDto
    {
        [Key]
        public Guid LoggingGuidId { get; set; }
    }
}
