using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Logging
    {
        [Key]
        public Guid LoggingGuidId { get; set; }
        public string LogError { get; set; }
        public string LogInfo { get; set; }
        public string LogDebug { get; set; }
    }
}
