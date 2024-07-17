using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Holiday
    {
        [Key]
        public Guid HolidayGuidId { get; set; }
        public DateTime HolidayFirstDate { get; set; }
        public DateTime HolidayFinishDate { get; set; }
        public string HolidayName { get; set; }

    }
}
