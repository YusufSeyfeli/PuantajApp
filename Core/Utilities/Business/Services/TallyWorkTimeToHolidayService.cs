using Core.Utilities.Business.Services.Abstracts;
using Core.Utilities.Business.Services.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Concrete;
using Entities.Dtos.HolidayDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services
{
    public class TallyWorkTimeToHolidayService: ITallyWorkTimeToHolidayService
    {
        public async Task<IResult> IsWorkTimeHoliday(DateTime firstDateTally, DateTime finishDateTally,List<HolidayDto> holidayDtoList)
        {
            List<DateTime> holidayDates = new List<DateTime>();

            foreach (var holidayTime in holidayDtoList)
            {
                DateTime firstDateTime = holidayTime.HolidayFirstDate;
                DateTime finishDateTime = holidayTime.HolidayFinishDate;

                holidayDates.Add(firstDateTime.Date);
                holidayDates.Add(finishDateTime.Date);
            }
            if (holidayDates.Contains(firstDateTally.Date))
            {
                //throw new Exception(ServiceMessages.IsFirstDayHolidayTime);

                return new ErrorResult(ServiceMessages.IsFirstDayHolidayTime);
            }
            else if (holidayDates.Contains(finishDateTally.Date))
            {
                //throw new Exception(ServiceMessages.IsFinishDayHolidayTime);

                return new ErrorResult(ServiceMessages.IsFinishDayHolidayTime);
            }

            return new SuccessResult();
        }
    }
}
