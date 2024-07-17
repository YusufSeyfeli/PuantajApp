using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Abstracts
{
    public interface IWeekTallyCountService
    {
        public Task<int> WeekTallyCountHour(DateTime firsDate, DateTime finishDate);

    }
}
