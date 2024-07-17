using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.SettingsDtos
{
    public class SettingsGetListDto
    {
        public Guid SettingsGuidId { get; set; }
        public int MontHour { get; set; }
        public int WeekHour { get; set; }
        public int DayHour { get; set; }
    }
}
