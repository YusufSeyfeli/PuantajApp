using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Tally
    {
        [Key]
        public Guid TallyGuidId { get; set; }
        public DateTime JobDate { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int CountHour { get; set; }
        public Guid StudentGuidId { get; set; }
        public Student Student { get; set; }

    }
}
