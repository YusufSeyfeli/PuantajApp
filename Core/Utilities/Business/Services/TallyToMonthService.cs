using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Business.Services.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Concrete;
using Entities.Dtos.TallyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services
{
    public class TallyToMonthService : ITallyToMonthService
    {

        public async Task<IResult> IsMonthTimeExist(DateTime firstDate, DateTime finishDate, Guid StudentGuidId, int currentMonthTotalHours, int monthHour, List<TallyCalculatorDto> tallyCalculatorDtos)
        {
            int totalHoursForSpecificMonth = 0;

            if (firstDate.Month == finishDate.Month)
            {
                foreach (var tally in tallyCalculatorDtos)
                {
                    if (tally.FirstDate.Month == firstDate.Month)
                    {
                        totalHoursForSpecificMonth += tally.TallyCountHour;
                    }
                }
            }
            else
            {
                return new ErrorResult(ServiceMessages.IsSameMonth);
            }

            if ((totalHoursForSpecificMonth + currentMonthTotalHours) > monthHour)
            {
                return new ErrorResult(ServiceMessages.MonthHourExceed);
            }
            else
            {
                return new SuccessResult();
            }
            
        }

    }
}
