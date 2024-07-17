using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.TallyDtos
{
    public class TallyGetListDto
    {

        public Guid TallyGuidId { get; set; }
        public DateTime JobDate { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int CountHour { get; set; }
        public Guid StudentGuidId { get; set; }
    }
}
