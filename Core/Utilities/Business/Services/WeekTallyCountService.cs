using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Business.Services.Abstracts;

namespace Core.Utilities.Business.Services
{
    public class WeekTallyCountService : IWeekTallyCountService
    {
        public async Task<int> WeekTallyCountHour(DateTime firsDate, DateTime finishDate)
        {
            TimeSpan timeDifference = finishDate - firsDate; //seçilen saatlerin hesabını yapıyor
            int hoursDifference = (int)timeDifference.TotalHours;

            return hoursDifference;

        }
    }
}
