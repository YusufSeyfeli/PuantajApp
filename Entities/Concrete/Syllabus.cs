using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Syllabus
    {
        [Key]
        public Guid SyllabusGuidId { get; set; }
        public Guid StudentGuidId { get; set; }
        public DateTime FirstTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime DayTime { get; set; }
        public Student Student { get; set; }
    }
}
