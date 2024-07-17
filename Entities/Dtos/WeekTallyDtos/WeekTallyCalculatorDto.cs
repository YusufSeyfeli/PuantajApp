using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.WeekTallyDtos
{
    public class WeekTallyCalculatorDto
    {
        public DateTime FirstDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Guid StudentGuidId { get; set; }
        public int CountHour { get; set; }
    }
}
