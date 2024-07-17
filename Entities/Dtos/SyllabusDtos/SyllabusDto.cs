using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.SyllabusDtos
{
    public class SyllabusDto
    {
        public Guid StudentGuidId { get; set; }
        public DateTime FirstTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime DayTime { get; set; }
    }
}
