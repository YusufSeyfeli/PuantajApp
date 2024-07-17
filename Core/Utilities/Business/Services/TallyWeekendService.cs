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
    public class TallyWeekendService: ITallyWeekendService
    {
        public async Task<IResult> IsWeekend(DateTime firsDateTally, DateTime finishDateTally)
        {
            if ((firsDateTally.DayOfWeek == DayOfWeek.Saturday) || (firsDateTally.DayOfWeek == DayOfWeek.Sunday)
            || (finishDateTally.DayOfWeek == DayOfWeek.Saturday) || (finishDateTally.DayOfWeek == DayOfWeek.Sunday))
            {
                //throw new Exception(ServiceMessages.WorkTimeWeekend);
                return new ErrorResult(ServiceMessages.WorkTimeWeekend);
            }
            return new SuccessResult();
        }
    }
}
