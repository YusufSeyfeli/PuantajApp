using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.LoggingDtos
{
    public class LoggingGetListDto
    {
        public Guid LoggingGuidId { get; set; }
        public string LogError { get; set; }
        public string LogInfo { get; set; }
        public string LogDebug { get; set; }
    }
}
