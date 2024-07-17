using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Settings
    {
        [Key]
        public Guid SettingsGuidId { get; set; }
        public int MontHour{ get; set; }
        public int WeekHour { get; set; }
        public int DayHour { get; set; }
    }
}
