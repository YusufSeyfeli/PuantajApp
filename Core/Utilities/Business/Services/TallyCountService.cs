using Core.Utilities.Business.Services;
using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Business.Services.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services
{
    public class TallyCountService: ITallyCountService
    {
        public async Task<int> TallyCountHour(DateTime firsDate, DateTime finishDate)
        {
            TimeSpan timeDifference = finishDate - firsDate; //seçilen saatlerin hesabını yapıyor
            int hoursDifference = (int)timeDifference.TotalHours;

            return hoursDifference;

        }
    }
}
