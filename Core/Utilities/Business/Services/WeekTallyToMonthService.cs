using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Business.Services.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Dtos.TallyDtos;
using Entities.Dtos.WeekTallyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services
{
    public class WeekTallyToMonthService : IWeekTallyToMonthService
    {

        public async Task<IResult> IsMonthTimeExist(DateTime firstDate, DateTime finishDate, Guid StudentGuidId, int currentMonthTotalHours, int monthHour, List<WeekTallyCalculatorDto> weekTallyCalculatorDtos)
        {
            int totalHoursForSpecificMonth = 0;

            if (firstDate.Month == finishDate.Month)
            {
                foreach (var tally in weekTallyCalculatorDtos)
                {
                    if (tally.FirstDate.Month == firstDate.Month)
                    {
                        totalHoursForSpecificMonth += tally.CountHour;
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
