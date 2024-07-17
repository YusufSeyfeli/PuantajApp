using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.SyllabusDtos
{
    public class SyllabusGetListDto
    {
        public Guid SyllabusGuidId { get; set; }
        public Guid StudentGuidId { get; set; }
        public DateTime FirstTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime DayTime { get; set; }
    }
}
