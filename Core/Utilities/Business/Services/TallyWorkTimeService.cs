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
    public class TallyWorkTimeService: ITallyWorkTimeService
    {
        public async Task<IResult> IsWorkTime(DateTime firstDateTally, DateTime finishDateTally)
        {
            TimeSpan workStartTime = new TimeSpan(8, 30, 0);
            TimeSpan workEndTime = new TimeSpan(17, 30, 0);

            TimeSpan firstTime = firstDateTally.TimeOfDay;
            TimeSpan finishTime = finishDateTally.TimeOfDay;

            if (firstTime < workStartTime || firstTime > workEndTime)
            {
                //throw new Exception(ServiceMessages.IsWorkTimeFinish);

                return new ErrorResult(ServiceMessages.IsWorkTimeFirst);
            }

            if (finishTime < workStartTime || finishTime > workEndTime)
            {
                //throw new Exception(ServiceMessages.IsWorkTimeFinish);
                return new ErrorResult(ServiceMessages.IsWorkTimeFinish);
            }

            return new SuccessResult();
        }
    }
}
