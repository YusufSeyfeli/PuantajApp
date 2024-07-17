using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.HolidayDtos
{
    public class HolidayDto
    {
        public DateTime HolidayFirstDate { get; set; }
        public DateTime HolidayFinishDate { get; set; }
        public string HolidayName { get; set; }
    }
}
